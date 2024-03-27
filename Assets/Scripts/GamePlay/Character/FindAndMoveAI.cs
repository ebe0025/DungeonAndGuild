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



            //탐색 딜레이 조정
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
            //피직스 구 탐지를 활용해서 감지된 타켓들을 모음
            Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, NAV_RANGE, targetLayers);

            //없으면 이동하지 않고 리턴
            if (hitTargets.Length == 0)
            {
                target = null;
                rb.velocity = Vector2.zero;
                return;
            }

            //가장 가까운 적을 찾기 위한 구조
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
            //공격 범위까지 들어왔으면 이동을 멈춤
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
