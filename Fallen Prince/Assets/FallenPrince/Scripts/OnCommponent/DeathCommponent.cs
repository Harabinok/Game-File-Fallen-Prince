using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FallenPrice.GameSetting.AI;
using FallenPrice.Model;

namespace FallenPrice.Component
{
    public class DeathCommponent : MonoBehaviour
    {
        public UnityEvent _actionDia;
        public UnityEvent _ActionRevival;
        AI _ai;
        Animator _animtor;


        private static int _Dead = Animator.StringToHash("Dead");

        private void Awake()
        {
            _ai = GetComponent<AI>();
            _animtor = GetComponentInChildren<Animator>();
        }
        public void Dead(bool Dia)
        {
            
            var Enemy = FindObjectOfType<GameData>();
            Enemy.NewUnit();
            _actionDia?.Invoke();
            _ai.Dia(true);
        }

        public void RestartLifeUndead()
        {
            if(_ActionRevival != null)
            {
                _ai._MyUnit = true;
                _ActionRevival.Invoke();
            }
        }
    }
}

