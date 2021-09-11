using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FallenPrice.Component;
using FallenPrice.GameSetting;


namespace FallenPrice.Abilites
{
    public class ResurrectionUndead : MonoBehaviour
    {
        [SerializeField] public string NameAbilities = "Resurrection";
        [SerializeField] GameObject Abilities;
        [SerializeField] GameObject SpriteAbilities;
        [SerializeField] private float DeleteAbilities;
        private Vector2 _radiusAbilities;
        [SerializeField] private float Radius;
        private Vector2 _oldPositionBullet;
        ManagementGameSettings _managementGameSettings;
        private Player _player;
        [SerializeField] private UnityEvent _ation;
        private bool _actionAbilitie = false;

        [SerializeField] Collider2D[] _intaractResult = new Collider2D[5];
        [SerializeField] private LayerMask Layer;

        BulletPositionCommponent bulletPosition;



        private void Awake()
        {
            bulletPosition = FindObjectOfType<BulletPositionCommponent>();
            _player = FindObjectOfType<Player>();
            _managementGameSettings = FindObjectOfType<ManagementGameSettings>();
        }
        private void Start()
        {
            _radiusAbilities = new Vector2(Radius, Radius);
            gameObject.transform.localScale = _radiusAbilities;
        }
        private void OnEnable()
        {
            ActionAbilition();

        }

        public void ActionAbilition()
        {
            _actionAbilitie = true;
            if (_ation != null)
            {
                _ation.Invoke();
            }
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, Radius, _intaractResult, Layer);
            for (int i = 0; i < size; i++)
            {
                var hp = _intaractResult[i].GetComponent<HealthCommponent>();
                if (hp._Health <= 0)
                {
                    
                    if (hp.tag == "Enemy")
                    {
                        hp.revival();
                    }
                }
            }
            

                  
   


            
        }
        private void Update()
        {
            if(_player.NameAbilities != NameAbilities && !_actionAbilitie)
            {
                _actionAbilitie = false;
                Destroy(gameObject);
            }
            var attack = _managementGameSettings.Attack;
            //if (Input.GetKeyDown(attack))
            //{
            //    _actionAbilitie = true;
            //    if (_actionAbilitie)
            //    {
            //        ActionAbilition();
            //    }

            //}
            print(_actionAbilitie);
            if (_actionAbilitie)
            {
                DeleteAbilities -= Time.deltaTime;
                if (DeleteAbilities <= 0)
                {
                    DestroyObject();
                }
            }
            
           

        }



        public void DestroyObject()
        {
            Destroy(gameObject);
        }

    }
}

