using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class Ranger : Character
    {
        public override void TakenDamage(int amount)
        {
            base.TakenDamage(amount);
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
