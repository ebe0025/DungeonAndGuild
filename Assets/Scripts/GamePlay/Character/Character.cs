using Core;
using log4net.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace GamePlay
{
    enum State
    {
        LIVE, INJURED, FATAL_INJURED, DEAD, BODY_DAMAGE 
    }

    public class Character : MonoBehaviour, IHealthState, IMovementState, IAttackState
    {
        public event Action<int> HealthChanged;
        public event Action DeadEvent;

        [SerializeField]
        protected string characterName;
        [SerializeField]
        protected int maxHp = 100;
        public int MaxHp { get { return maxHp; } set {  maxHp = value; } }
        [SerializeField]
        protected int curHp = 0;
        public int CurHp
        {
            get { return curHp; } 
            set 
            { 
                curHp = value;
                HealthChanged?.Invoke(curHp);

                if(curHp < 0)
                {
                    Dead();
                    
                }
            } 
        }

        [SerializeField]
        protected float moveSpeed = 1;
        public float MoveSpeed
        {
            get { return moveSpeed; }
            set { moveSpeed = value; }
        }
        [SerializeField]
        protected int attack = 1;
        public int Attack { get { return attack; } set {  attack = value; } }

        [SerializeField]
        private float attackRange;
        public float AttackRange { get { return attackRange; } set { attackRange =  value; } }
        [SerializeField]
        private float attackDelay;
        public float AttackDelay { get {  return attackDelay; } set { attackDelay = value; } }
        [SerializeField]
        private float damageDelay = 0.3f;
        public float DamageDelay { get { return damageDelay; } set { damageDelay = value; } }

        [SerializeField]
        protected int defense = 1;

        [SerializeField]
        protected int level = 1;
        [SerializeField]
        protected int curExp = 0;
        [SerializeField]
        protected int expForNext = 100;

        [SerializeField]
        protected Animator animator;

        protected Collider2D collider;

        private bool isDead = false;

        protected void Awake()
        {
            animator = GetComponent<Animator>();
            curHp = maxHp;
            collider = GetComponent<Collider2D>();
        }
        public virtual void GainExp(int amount)
        {
            curExp += amount;
        }

        protected virtual void CheckLevelUp()
        {
            while(curExp >= expForNext)
            {
                curExp -= expForNext;
                LevelUp();
                UpdateNextLevelExp();

            }
        }
        protected void LevelUp()
        {
            level++;
        }
        protected void UpdateNextLevelExp()
        {

        }

        public virtual void TakenDamage(int amount)
        {
            CurHp -= amount;
        }


        protected virtual void Dead()
        {
            if (gameObject.layer == LayerMask.NameToLayer("Dead")) return;
            gameObject.layer = LayerMask.NameToLayer("Dead");
            animator.SetTrigger("Dead");
            DeadEvent?.Invoke();
            collider.enabled = false;

        }




    }
}
