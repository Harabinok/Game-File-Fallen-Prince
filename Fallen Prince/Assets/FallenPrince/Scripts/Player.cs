using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FallenPrice.GameSetting.AI;
using FallenPrice.GameSetting;
using FallenPrice.UICommponent;
using FallenPrice.Component;


namespace FallenPrice
{
    public class Player : MonoBehaviour
    {
        [SerializeField] public int _money;
        [SerializeField] Text _moneyText;
        [SerializeField] private float _speed;
        private float _direction;
        private float _directionUP;
        [SerializeField] private float _restartFireAbilities;
        private float _coolDown;
        private bool _cooldown;
        public GameObject _actionAbilities;
        [SerializeField] private Transform BullitePosition;
        Rigidbody2D _rigidbody2D;
        AbilitiesMannager _abilitiesMannager;
        public bool AllowedFire = false;
        [SerializeField] public string NameAbilities;

        [SerializeField] public Vector3 PositionPlayer;
        [SerializeField] AttackComponent _attackComponent;

        [SerializeField] private LayerMask InteractableLayer;
        [SerializeField] private Collider2D[] results = new Collider2D[1];

        
        private void Awake()
        {
            

            _rigidbody2D = GetComponent<Rigidbody2D>();
            _abilitiesMannager = GetComponent<AbilitiesMannager>();

            PositionPlayer = transform.position;


        }
        public void LoadSave(Save.PlayerSaveData save)
        {

            transform.position = new Vector3(save.Position.x, save.Position.y, save.Position.z);
        }


        public void Abilities(GameObject SelectedAbility, float TimeRestart, string Name)
        {
            _restartFireAbilities = TimeRestart;
            _coolDown = TimeRestart;
            _actionAbilities = SelectedAbility;
            NameAbilities = Name;
        }

        public void Interactable()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position,5,results , InteractableLayer);
            for (int i = 0; i < size; i++)
            {
                
                    var _Interactable = results[i].GetComponent<Interactable>();
                    _Interactable.Action();
                
            }
        }

        public void OpenFire(bool OpenFire)
        {
            AllowedFire = OpenFire;
        }
        public void Attack()
        {

            if(NameAbilities != null && !_cooldown)
            {
                _attackComponent.SetAbilities(NameAbilities);
            }
            _cooldown = true;

        }
        private void CoolDown()
        {
            if (_cooldown)
            {


                var i = _restartFireAbilities -= Time.deltaTime;
                if (i <= 0)
                {
                    _cooldown = false;
                    _restartFireAbilities = _coolDown;
                }

            }
        }

        public void SetDirection(float Direction, float UpDirection)
        {


            _direction = Direction;
            _directionUP = UpDirection;
            if (_direction > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (_direction < 0)
            {
                transform.localRotation = Quaternion.Euler(0, -180, 0);
            }



        }
        private void Update()
        {
            CoolDown();
            PositionPlayer = transform.position;
            _moneyText.text = $"{_money}";
        }
        private void FixedUpdate()
        {

            _rigidbody2D.velocity = new Vector2(_speed * _direction, _speed * _directionUP);
        }
    }
}

 