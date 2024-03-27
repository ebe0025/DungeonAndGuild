using Core;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace GamePlay
{
    public class FindAndMoveAI : MonoBehaviour
    {
        [SerializeField]
        private LayerMask targetLayers;

        IMovementState charMovement;
        IAttackState charAttack;
        [SerializeField]
        private Transform target;
        public Transform Target { get { return target; } set { target = value; } }

        const float NAV_RANGE = 10000f;
        private bool stopEvent = false;

        private Animator animator;
        private Rigidbody2D rb;

        [SerializeField]
        private float targetSearchInterval = 0.2f;
        private float timer = 0f;

        private void Awake()
        {
            charMovement = GetComponent<IMovementState>();
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            charAttack = GetComponent<IAttackState>();
        }

        private void Update()
        {
            if (stopEvent || gameObject.layer == LayerMask.NameToLayer("Dead")) return;



            //Ž�� ������ ����
            timer += Time.deltaTime;
            if (timer >= targetSearchInterval)
            {
                FindTarget();
                timer = 0f;
            }


            if (target != null)
                MoveToTarget(target, charMovement.MoveSpeed);
            animator.SetFloat("Speed", rb.velocity.magnitude);

        }
        private void FindTarget()
        {
            //������ �� Ž���� Ȱ���ؼ� ������ Ÿ�ϵ��� ����
            Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, NAV_RANGE, targetLayers);

            //������ �̵����� �ʰ� ����
            if (hitTargets.Length == 0)
            {
                target = null;
                rb.velocity = Vector2.zero;
                return;
            }

            //���� ����� ���� ã�� ���� ����
            float closestDistnace = Mathf.Infinity;

            foreach (Collider2D target in hitTargets)
            {
                float distnace = Vector2.Distance(transform.position, target.transform.position);

                if (distnace < closestDistnace)
                {
                    closestDistnace = distnace;
                    this.target = target.transform;
                }
            }
        }

        private void MoveToTarget(Transform _target, float _moveSpeed)
        {
            //���� �������� �������� �̵��� ����
            if (target != null && Vector2.Distance(transform.position, target.position) < charAttack.AttackRange)
            {
                rb.velocity = Vector2.zero;
                return;
            }

            Vector2 dir = _target.position - transform.position;
            dir.Normalize();
            Vector2 velocity = dir * _moveSpeed;
            rb.velocity = velocity;
        }
    }
}
