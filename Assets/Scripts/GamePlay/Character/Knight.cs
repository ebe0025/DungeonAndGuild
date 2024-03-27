using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class Knight : Character
    {
 
        public override void GainExp(int amount)
        {
            base.GainExp(amount);
        }

        protected override void CheckLevelUp()
        {
            base.CheckLevelUp();
        }

        protected override void Dead()
        {
            base.Dead();
        }

        public override void TakenDamage(int amount)
        {
            base.TakenDamage(amount);
        }
    }
}
