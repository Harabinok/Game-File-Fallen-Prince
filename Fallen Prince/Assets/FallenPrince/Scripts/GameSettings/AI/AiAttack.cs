using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenPrice.GameSetting.AI;
using FallenPrice;
using FallenPrice.Component;

namespace FallenPrice.GameSetting.AI
{
    public class AiAttack : MonoBehaviour
    {
        [SerializeField] private int Damage;
        [SerializeField] public float _CoolDown;
        [SerializeField] public float _distanceAttack;
        [SerializeField] private LayerMask GoalAttack;
        [SerializeField] private Collider2D[] GoalResult = new Collider2D[2];
        [SerializeField] private Transform _positionAttack;

        [SerializeField] AI aI;
        AiSee _aiSee;

        private float CoolDownTime;

        private void Awake()
        {
            _aiSee = GetComponent<AiSee>();
            CoolDownTime = _CoolDown;
        }

        public bool InBattle()
        {
            if(GoalAttack <= _distanceAttack)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        static int _Attack = Animator.StringToHash("Attack");
        public void Attack()
        {
            
            aI._animator.SetTrigger(_Attack);
        }
        public void AttackByTarget()
        {
            var size = Physics2D.OverlapCircleNonAlloc(_positionAttack.position, _distanceAttack, GoalResult, GoalAttack);
            if (!aI._MyUnit)
            {
                for (int i = 0; i < size; i++)
                {
                    var HpPlayer = GoalResult[i].GetComponent<PlayerHealth>();
                    var HpUnit = GoalResult[i].GetComponent<HealthCommponent>();
                    if (HpPlayer != null)
                    {
                        HpPlayer.DamageCaused(Damage);
                    }
                    if(HpUnit != null)
                    {
                        HpUnit.Dia(Damage);
                    }
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    var Hp = GoalResult[i].GetComponent<HealthCommponent>();
                    if (Hp != null)
                    {
                        Hp.Dia(Damage);
                        if (Hp._Health <= 0)
                        {

                            GoalResult[i] = null;
                        }

                    }
                }
            }
        }
    }
}


