using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenPrice.Model;

namespace FallenPrice.GameSetting.AI
{
    public class AiSee : MonoBehaviour
    {

        [SerializeField] public GameObject _target;
        public CircleCollider2D GameSettingCollider2D;
        [SerializeField]
        bool SeeTarget;

        Animation anim;
        Model.GameData unitData;
        Player _player;
        AI _ai;

        private void Awake()
        {
            
            _ai = GetComponentInParent<AI>();
            _player = FindObjectOfType<Player>();
            unitData = FindObjectOfType<Model.GameData>();
            GameSettingCollider2D = GetComponent<CircleCollider2D>();

        }
        ////////////////////Friend////////////////////
        GameObject FindGameObjectMinDistantion()
        {
            if (_ai._MyUnit)
            {
                _ai = GetComponentInParent<AI>();
                float Distantion = Mathf.Infinity;
                Vector3 Position = transform.position;
                foreach (var Target in unitData.Enemy)
                {
                    Vector3 Deff = Target.transform.position - Position;
                    float CurrentTarget = Deff.sqrMagnitude;
                    if (CurrentTarget < Distantion)
                    {
                        if(_target == null || _target != unitData.Player)
                        {
                            _target = Target;
                            Distantion = CurrentTarget;
                        }
                        
                    }
                }
                if (_target != null && _target != unitData.Player)
                {
                    var _Target = _target.GetComponent<AI>();
                    if (!_Target._dead)
                    {
                        return _target;
                    }
                }
                else
                {
                    SeeTarget = false;
                }
                return null;
            }
            return null;
        }

        ////////////////////Friend////////////////////




        /////////////////////Enemy////////////////////
        GameObject FindGameObjectMinDistantionEnemy()
        {
            if (!_ai._MyUnit)
            {

                _ai = GetComponentInParent<AI>();
                float Distantion = Mathf.Infinity;
                Vector3 Position = transform.position;
                foreach (var Target in unitData.Friend)
                {
                    Vector3 Deff = Target.transform.position - Position;
                    float CurrentTarget = Deff.sqrMagnitude;
                    if (CurrentTarget < Distantion)
                    {
                        if (Vector2.Distance(this.transform.position, Target.transform.position) >
                        Vector2.Distance(this.transform.position, unitData.Player.transform.position))
                        {
                            SeeTarget = false;
                        }
                        else
                        {
                            if (_target == null)
                            {
                                _target = Target;
                                Distantion = CurrentTarget;
                            }
                            
                        }
                    }
                    
                }
                if (_target != null && _target != unitData.Player)
                {
                    var _Target = _target.GetComponent<AI>();
                    if (!_Target._dead)
                    {
                        return _target;
                    }
                }
                else
                {
                    SeeTarget = false;
                }
                
            }
            return null;
        }
        /////////////////////Enemy////////////////////

        /////////////////////////Settings////////////////////////////
        private void OnTriggerStay2D(Collider2D other)
        {
            if (_ai._MyUnit)
            {
                if (unitData.NumberOfEnemies != 0)
                {
                    SeeTarget = true;
                }
                else
                {
                    SeeTarget = false;
                }
            }
               
            if (!_ai._MyUnit)
            {
                if (unitData.NumberOfFriend != 0)
                {
                    SeeTarget = true;
                }
                else
                {
                    SeeTarget = false;
                }
            }
                
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_ai._MyUnit)
            {
                if (unitData.NumberOfEnemies != 0)
                {
                    SeeTarget = true;
                }
                else
                {
                    SeeTarget = false;
                }
            }
               
                    
            if (!_ai._MyUnit)
            {
                if (unitData.NumberOfFriend != 0)
                {
                    SeeTarget = true;
                }
                else
                {
                    SeeTarget = false;
                }

            }
               
           
        }
        private void Update()
        {

            ////////////////////Friend////////////////////
            if (_ai._MyUnit)
            {
                if (SeeTarget)
                    _target = FindGameObjectMinDistantion();
                else
                    _target = unitData.Player;
            }
            ////////////////////Friend////////////////////
            


            /////////////////////Enemy////////////////////
            if (!_ai._MyUnit)
            {

                if (SeeTarget)
                    _target = FindGameObjectMinDistantionEnemy();
                else
                    _target = unitData.Player;
            }
            /////////////////////Enemy////////////////////
        }
        public void NewPurpose()
        {
            _target = null;
        }
        /////////////////////////Settings///////////////////////////
    }
}
           