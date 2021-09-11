using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FallenPrice.GameSetting.AI;

namespace FallenPrice.GameSetting.AI
{
    public class AIMovement : MonoBehaviour
    {
        [Header("Enemy")]
        [SerializeField] private LayerMask targetMask;
        [SerializeField] private LayerMask ignoreMask;
        [SerializeField] private float AdditionalTurningDistance;
        [SerializeField] [Range(1, 100)] private int rays = 3;
        [SerializeField] [Range(1, 30)] private float distance = 5;
        [SerializeField] [Range(0, 360)] private float angle = 20;
        [SerializeField] private Transform rayPoint;
        private int invert = 1;
        public Transform viewCamera;
        [SerializeField] private Vector2 OldPosition;
        [SerializeField] private Vector2 StartPosition;
        [SerializeField] private Vector2 _currentPositionEnemy;
        [SerializeField] private RaycastHit2D[] GoalResult = new RaycastHit2D[1];
        
        

        private float MemoryPosition;
        private bool _dead = false;
       [SerializeField] private bool MemoryPositionPlayer = false;
        Player _player;
        AI _ai;
        AiAttack _aiAttack;
        [SerializeField]AIEnemy[] _aiEnemy;
        AIFriend[] _aiFriends;
        AiSee _aiSee;
        NavMeshAgent _agent;
        private int _currendEnemu;
        private int _currendFriend;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _aiAttack = FindObjectOfType<AiAttack>();
            _aiFriends = FindObjectsOfType<AIFriend>();
            _aiEnemy = FindObjectsOfType<AIEnemy>();
            _player = FindObjectOfType<Player>();
            _ai = GetComponent<AI>();
            _aiSee = GetComponentInChildren<AiSee>();
            StartPosition = transform.position;
            for (int i = 0; i < _aiEnemy.Length; i++)
            {
                _currendEnemu = i;
                MemoryPosition = _aiEnemy[i].MemoryTime;
            }

            for (int i = 0; i < _aiFriends.Length; i++)
            {
                if(_ai._MyUnit)
                
                _currendFriend = i;
            }
        }

        public Vector2 SeeAtPoint()
        {
            return OldPosition;
        }
        void Update()
        {
            Movement();
           
        }
        private void MyUnit()
        {
            if (_ai._MyUnit)
            {
                var Target = _aiSee._target;
                if (_aiSee._target != null)
                {
                    OldPosition = Target.transform.position;
                    _ai.AISetDirectionHorizontal(1, OldPosition);
                    rotation();
                }
                
            }
                
        }
        private void NotMyUnit()
        {
            if (!_dead && !_ai._MyUnit)
            {
                if (Scan() && !_dead && !_ai._MyUnit)
                {
                    _ai._move = true;
                    SeeAtPoint();
                    rotation();
                    if (_ai._aiSee._target != null)
                    OldPosition = _aiSee._target.transform.position;
                    Agry(1, OldPosition);
                    MemoryPositionPlayer = true;
                    _aiEnemy[_currendEnemu].MemoryTime = MemoryPosition;
                }
                if (!MemoryPositionPlayer && !_ai._MyUnit && !_dead)
                {
                    rotation();
                    OldPosition = StartPosition;
                    _ai.AISetDirectionHorizontal(0, OldPosition);
                    if(_currentPositionEnemy == StartPosition)
                    {
                        _ai._move = false;
                    }

                }
                else if (!_ai._MyUnit && !Scan() && MemoryPositionPlayer && !_dead)
                {

                    _aiEnemy[_currendEnemu].MemoryTime -= Time.deltaTime;
                    if (_aiEnemy[_currendEnemu].MemoryTime <= 0)
                    {

                        _aiEnemy[_currendEnemu].MemoryTime = MemoryPosition;
                        MemoryPositionPlayer = false;

                    }
                    rotation();
                    OldPosition = _player.transform.position;
                    _ai.AISetDirectionHorizontal(0, OldPosition);
                }
            }
        }

     
        public void Movement()
        {
          
            _currentPositionEnemy = transform.position;
            if(_ai._MyUnit)
                MyUnit();
            if (!_ai._MyUnit)
                NotMyUnit();
        }
        
        private void rotation()
        {
            if (MemoryPositionPlayer == false)
            {
                if (OldPosition.x < _currentPositionEnemy.x)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                if (OldPosition.x > _currentPositionEnemy.x)
                {
                    transform.localRotation = Quaternion.Euler(0, -180, 0);
                }

            }
            if (_ai._MyUnit)
            {
                if (_aiSee._target.transform.position.x < _currentPositionEnemy.x)
                {
                    transform.localRotation = Quaternion.Euler(0, -180, 0);
                }
                if (_aiSee._target.transform.position.x > _currentPositionEnemy.x )
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }
            if (Scan() && !_ai._MyUnit)
            {
                if (OldPosition.x < _currentPositionEnemy.x)
                {
                    transform.localRotation = Quaternion.Euler(0, -180, 0);
                }
                if (OldPosition.x > _currentPositionEnemy.x)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }

            }
            else if (!Scan() && !_ai._MyUnit)
            {
                if (SeeAtPoint().x < _currentPositionEnemy.x)
                {
                    transform.localRotation = Quaternion.Euler(0, -180, 0);
                }
                if (SeeAtPoint().x > _currentPositionEnemy.x)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
        void Agry(int Direction, Vector2 Position)
        {

            _ai.AISetDirectionHorizontal(Direction, Position);

        }

        public void Dead(bool dia)
        {
            _dead = dia;
        }

        public void PlatfomerFlip()
        {
            invert *= -1;
        }

        bool GetRay(Vector2 dir)
        {
            if (!_ai._MyUnit)
            {
                bool result = false;

                var hit = Physics2D.Raycast(rayPoint.position, dir, distance, ~ignoreMask);
                if (hit.collider != null)
                {
                    if (CheckObject(hit.collider.gameObject))
                    {
                        result = true;
                        Debug.DrawLine(rayPoint.position, hit.point, Color.green);

                        // луч попал в цель
                    }
                    else
                    {

                        Debug.DrawLine(rayPoint.position, hit.point, Color.blue);
                        // луч попал в любой другой коллайдер
                    }
                }
                else
                {
                    Debug.DrawRay(rayPoint.position, dir * distance, Color.red);
                    // луч никуда не попал
                }
                return result;
            }
            return false;
        }


        bool CheckObject(GameObject obj)
        {
            if (((1 << obj.layer) & targetMask) != 0)
            {
                return true;
            }

            return false;
        }

       public bool Scan()
        {
            bool hit = false;
            float j = 0;

            for (int i = 0; i < rays; i++)
            {
                var x = Mathf.Sin(j);
                var y = Mathf.Cos(j);

                j += angle * Mathf.Deg2Rad / rays * invert;

                if (x != 0)
                {
                    if (GetRay(rayPoint.TransformDirection(new Vector3(y, -x, 0)))) hit = true;
                }

                if (GetRay(rayPoint.TransformDirection(new Vector3(y, x, 0)))) hit = true;
            }

            return hit;
        }


    }
}

 