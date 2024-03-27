using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class MeleeAttackSystem : MonoBehaviour
    {
        private IAttackState attacker;
        private Animator animator;
        private FindAndMoveAI findAndMoveAI;
        private Transform target;
        private bool isAttacking = false;

        [SerializeField]
        private IAttackStrategy attackStrategy;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            findAndMoveAI = GetComponent<FindAndMoveAI>();
            attacker = GetComponent<IAttackState>();

            // 공격 전략 설정
            attackStrategy = new BasicMeleeAttackStrategy();
        }

        private void Update()
        {
            if (isAttacking || gameObject.layer == LayerMask.NameToLayer("Dead"))
            {
                return;
            }

            target = findAndMoveAI.Target;
            if (!isAttacking && target !=null)
            {
                StartCoroutine(PerformAttack());
            }
        }

        private IEnumerator PerformAttack()
        {
            isAttacking = true;
            yield return StartCoroutine(attackStrategy.ExecuteAttack(transform, target, animator, attacker));
            isAttacking = false;
        }


    }
}
