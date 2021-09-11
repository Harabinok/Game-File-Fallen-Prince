using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FallenPrice.GameSetting.AI;
using FallenPrice.Model;


namespace FallenPrice.GameSetting.AI
{
    public class AI : MonoBehaviour
    {
        public bool _MyUnit;
        public float _speed = 12f;
        protected Vector2 _position;
        public bool Move;
        public bool _InBattle;
       

        protected float _direction;
        public bool _dead = false;
        public bool _move;
        public float StopDistantinoOnPlayer;

        protected Rigidbody2D _rigidboody2D;
        protected AIMovement _aiMovement;
        [HideInInspector]
        public Player _player;
        protected NavMeshAgent _agent;
        [HideInInspector]
        public Animator _animator;
        [SerializeField] protected AiAttack _aiAttack;
        [HideInInspector]
        public UnitData _unitData;
        [HideInInspector]
        public AiSee _aiSee;
        protected AiAttack aiAttack;
        [Header("Audio")]
        [SerializeField] public AudioClip _damageAudio;


        protected static int _VerticalVelocity = Animator.StringToHash("Vertical-velocity");
        protected static int _IsRunning = Animator.StringToHash("IsRunneng");
        protected static int _hit = Animator.StringToHash("Hit");
        protected static int _Attack = Animator.StringToHash("Attack");
        protected static int _riveval = Animator.StringToHash("riveval");

        [HideInInspector] public GameObject Target;
        [HideInInspector] public AudioSource _audionSource;

        protected virtual void Awake()
        {
            _audionSource = GetComponent<AudioSource>();
            _player = FindObjectOfType<Player>();
            aiAttack = GetComponent<AiAttack>();
            _aiSee = GetComponentInChildren<AiSee>();
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
            _agent.stoppingDistance = StopDistantinoOnPlayer;
            _agent.speed = _speed;
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _position = transform.position;
            _rigidboody2D = GetComponent<Rigidbody2D>();
            _aiMovement = GetComponent<AIMovement>();
            _unitData = FindObjectOfType<UnitData>();
        }

        protected virtual void OnEnable()
        {
            _unitData.NewUnit();
        }

        public void Dia(bool _Dia)
        {
            _dead = _Dia;
            _aiMovement.Dead(_Dia);
        }

        public void AISetDirectionHorizontal(float Directin, Vector2 Position)
        {
            _direction = Directin;
            _position = Position;
            
        }


     
    }
    
}

 