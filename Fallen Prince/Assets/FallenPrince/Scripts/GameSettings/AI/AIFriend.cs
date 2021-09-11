using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenPrice.GameSetting.AI
{
    public class AIFriend : AI
    {


        [SerializeField] private float MinimaleDistantion;
        [SerializeField] public float SeeDistantion;
         private Transform Target;
        protected override void Awake()
        {
            Target = FindObjectOfType<Player>().transform;
            base.Awake();
        }


        private void FixedUpdate()
        {
            
        }
        protected void Update()
        {
            Movement();   
            Attack();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }
        private bool DistanceMinimal()
        {
            if (Vector2.Distance(transform.position, Target.position) > MinimaleDistantion + 1)
            {
                _move = true;
                _agent.speed = _speed;
                return false;

            }

            if (Vector2.Distance(transform.position, Target.position) <= MinimaleDistantion + 0.2f)
            {
                _move = false;
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                _agent.speed = 0;
                return true;
            }

            return false;
        }
        private void Movement()
        {
            Animation();
            DistanceMinimal();
            if (!DistanceMinimal())
            {
                _agent.enabled = true;
                _agent.SetDestination(_position);
            }

            else if (DistanceMinimal())
            {
                _agent.enabled = false;
            }
        }
        private void Attack()
        {
            if (_aiSee._target != null)
            {
                if (Vector2.Distance(this.transform.position, _aiSee._target.transform.position) <= aiAttack._distanceAttack)
                {
                    if (_aiSee._target != _unitData.Player)
                    {
                        _aiAttack.Attack();
                    }
                }
            }
            
        }

        public void LoadSave(Save.FriendSaveData save)
        {
            transform.position = new Vector3(save.Position.x, save.Position.y, save.Position.z);
        }
        private void Animation()
        {
            _animator.SetBool(_IsRunning, _move);

        }
    }
}

