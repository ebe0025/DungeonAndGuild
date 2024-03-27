using System;
using UnityEngine;




namespace Core
{
    public interface IHealthState
    {
        public event Action<int> HealthChanged;
        public event Action DeadEvent;
        public int MaxHp { get; }
        public int CurHp { get; }
    }

    public interface IMovementState
    {
        public float MoveSpeed { get; set; }
    }

    public interface IAttackState
    { 
        public int Attack {  get; set; }
        public float AttackRange { get; set; }
        public float AttackDelay { get; set; }
        public float DamageDelay { get; set; }
        public void TakenDamage(int amount);
    }

}
