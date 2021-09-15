using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenPrice.GameSetting.AI;

namespace FallenPrice.GameSetting.AI
{
    public class AIEnemy : AI
    {

        [SerializeField] public float MemoryTime;
        protected override void Awake()
        {
            base.Awake();
        }
        private void Update()
        {
            Movement();
            Attack();
        }
        protected override void OnEnable()
        {
            base.OnEnable();
        }
        private void Attack()
        {
            if(_aiSee._target != null)
            if(Vector2.Distance(this.transform.position, _aiSee._target.transform.position) <= _aiAttack._distanceAttack)
            _aiAttack.Attack();
        }
        private void Movement()
        {
            if (!_dead && _aiMovement.Scan())
            {
                if (Vector2.Distance(transform.position, _position) > _aiAttack._distanceAttack)
                {
                    Animations();
                    _agent.SetDestination(_position);
                }
            }
            else if (!_aiMovement.Scan())
            {
                Animations();
                _agent.SetDestination(_position);

            }
        }

        
        private void Animations()
        {
            _animator.SetBool(_IsRunning, _move );
        }
    }
}

