using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using Cinemachine;

namespace FallenPrice.InGameVideo
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private GameObject _Camera;
         private CinemachineBrain CMB;
         [SerializeField] private float _timeNextStages;
         private Transform _targetPosition;
        [SerializeField] private UnityEvent OnStop;
        private UnityEvent _action;
        [SerializeField] private Stages[] _stages;
      


         [SerializeField] private bool _seeCadrs;
          [SerializeField] private bool Movement;

         private int _currentNuber;
         private int _currentStages = 0;

        private void Awake()
        {
            CMB = _Camera.GetComponent<CinemachineBrain>();
            OnStop = null;
        }

        public void StartOneStage()
        {
            SetStage(1);
            Movement = true;
        }

        public void SetStage(int Number)
        {
            print("Ok");
            Movement = true;
            for (int i = 0; i < _stages.Length; i++)
            {
                
                if (_stages[i].Namber == Number)
                {
                    CMB.enabled = false;
                    _action = _stages[i].Action;
                    _targetPosition = _stages[i].MovePosition;
                    _currentNuber = i;
                   _timeNextStages = _stages[i].TimeNextPosition;
                    HistoreTime = _timeNextStages;
                    
                }
               

            }
        }
        public void NextState()
        {

        }

        public void StopStages()
        {
            CMB.enabled = true;
        }
        private float HistoreTime;
        public void Update()
        {
            
            if (Movement)
            {
                var Stages = _stages[_currentNuber];
                _seeCadrs = true;
                _Camera.transform.position = Vector2.MoveTowards(_Camera.transform.position, _targetPosition.position, Stages.MoveSpeed * Time.deltaTime);
                _Camera.transform.position = new Vector3(_Camera.transform.position.x, _Camera.transform.position.y, -28.92884f);
                if(_Camera.transform.position.x == _targetPosition.transform.position.x 
                    && _Camera.transform.position.y == _targetPosition.transform.position.y)
                {
                    if (_action != null)
                    {
                        _action.Invoke();
                    }
                    
                    _seeCadrs = true;
                }
            }
            if(_seeCadrs)
            {
                _timeNextStages -= Time.deltaTime;
                if(_timeNextStages <= 0)
                {
                    _seeCadrs = false;
                    _currentStages++;
                    SetStage(_currentStages);
                }
            }
        }
    }


    [Serializable]
    public class Stages
    {
        [SerializeField] private int _number;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _timeNextPosition;
        [SerializeField] private Transform _movePosition;
        [SerializeField] private UnityEvent _action;

        public int Namber => _number;
        public float MoveSpeed => _moveSpeed;
        public float TimeNextPosition => _timeNextPosition;
        public Transform MovePosition => _movePosition;
        public UnityEvent Action => _action;
    }
}

