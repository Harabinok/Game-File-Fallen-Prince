using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenPrice.Component;

namespace FallenPrice.Abilites
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] public string NameAbilities = "Fire Ball";
        [SerializeField] private float _speed;
        [SerializeField] private float Damage;
        [SerializeField] private GameObject _ball;


      [SerializeField]  BulletPositionCommponent SpawnPosition;
        HealthCommponent[] _healthCommponent;
        private void Awake()
        {
            _healthCommponent = FindObjectsOfType<HealthCommponent>();

        }

        private void OnEnable()
        {
            
            for (int i = 0; i < _healthCommponent.Length; i++)
            {
                _healthCommponent[i].Dia(Damage);
            }
        }

        private void Update()
        {

            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }

        public void Destroy()
        {
            Destroy(_ball);
        }
    }
}

