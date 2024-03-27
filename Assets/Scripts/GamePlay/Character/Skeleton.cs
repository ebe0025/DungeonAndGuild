using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class Skeleton : Character
    {
        public override void GainExp(int amount)
        {
            base.GainExp(amount);
        }

        public override void TakenDamage(int amount)
        {
            base.TakenDamage(amount);
            animator.SetTrigger("Hit");
            
        }

        protected override void CheckLevelUp()
        {
            base.CheckLevelUp();
        }

        protected override void Dead()
        {
            base.Dead();
        }
    }
}
