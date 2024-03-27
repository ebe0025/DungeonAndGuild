using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Core
{
    public interface IAttackStrategy
    {
        IEnumerator ExecuteAttack(Transform attacker,Transform target, Animator animator, IAttackState attackState);
    }
}
