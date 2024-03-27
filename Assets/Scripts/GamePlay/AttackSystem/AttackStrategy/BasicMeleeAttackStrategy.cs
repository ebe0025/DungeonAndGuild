using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class BasicMeleeAttackStrategy : IAttackStrategy
    {
        public IEnumerator ExecuteAttack(Transform attacker, Transform target, Animator animator, IAttackState attackState)
        {
            float distance = Vector2.Distance(target.position, attacker.position);
            if (distance < attackState.AttackRange)
            {
                animator.SetTrigger("Attack");
                yield return new WaitForSeconds(attackState.DamageDelay);
                IAttackState targetState = target.GetComponent<IAttackState>();
                if (target != null)
                {
                    targetState.TakenDamage(attackState.Attack);
                }
                yield return new WaitForSeconds(attackState.AttackDelay - attackState.DamageDelay);
            }
        }
    }
}
