using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using FallenPrice.GameSetting.AI;


namespace FallenPrice.Component
{
    [RequireComponent(typeof(DeathCommponent))]
    public class HealthCommponent : MonoBehaviour
    {
        [SerializeField] public float _Health;
        private float _Damage;
        [SerializeField] private UnityEvent OnDamage;
        [SerializeField] private UnityEvent OnDie;
        AI _ai;

        SpriteRenderer _color;
        DeathCommponent _deathCommponent;

        private void Awake()
        {
            _ai = GetComponent<AI>();
            _color = GetComponent<SpriteRenderer>();
            _deathCommponent = GetComponent<DeathCommponent>();
        }
       public void Teatment(int _Teatment)
        {
            _Health += _Teatment;
        }
        public void Dia(float Damage)
        {
            _Health -= Damage;
            hit();
            _ai._audionSource.PlayOneShot(_ai._damageAudio);
            if (OnDamage != null)
            {
                OnDamage.Invoke();
            }
            _Damage = Damage;
            if (_Health <= 0)
            {
                if(OnDie != null)
                {
                    OnDie.Invoke();
                }
                _deathCommponent.Dead(true);
            }
        }
       private void hit()
        {
            _color.color = Color.black;
        }
        float coolDownHit = 0.1f; 
        private void FixedUpdate()
        {
            if(_color.color == Color.black)
            {
                coolDownHit -= Time.deltaTime;
                if(coolDownHit <= 0)
                {
                    coolDownHit = 0.1f;
                    _color.color = Color.white;
                }
            }
            if (_Health <= 0) Dia(0);
        }
        public void revival()
        {
            _deathCommponent.RestartLifeUndead();
        }
        private void OnTriggerEnter2D(Collider2D collider)
        {
            
            if (collider.tag == "FireBall")
            {
                _Health -= _Damage;
            }

        }

    }
}

