using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

namespace FallenPrice.Component
{
    public class DialogueComponent : MonoBehaviour
    {

        [SerializeField] private Text _uiText;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float _timeLifeText;

        [SerializeField] private Stages[] _stages;
       [SerializeField]  private bool _dialogue;
        private int _currentStage;
        private int _currentNumber = 1;
        private int _maxNumber;

        private void Awake()
        {
           
            _uiText.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
            _maxNumber = _stages.Length;
            
        }
        public void Action(int Number)
        {
            for (int i = 0; i < _stages.Length; i++)
            {
                if (!_dialogue)
                {
                    if(_stages[i].NumberStage == Number)
                    {
                        HistoreTime = _stages[i].TimeLifeText;
                        _timeLifeText = HistoreTime;
                        _dialogue = true;
                        _uiText.text = _stages[i].Text;
                        if(_stages[i].Action != null)
                        {
                            _stages[i].Action.Invoke();
                        }
                        _currentStage = i;
                    }
                }
            }
        }
        private float HistoreTime;
        private void Update()
        {
            var Stage = _stages[_currentStage];
            if (_dialogue)
            {
                _uiText.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
                _timeLifeText -= Time.deltaTime;
                if(_timeLifeText <= 0)
                {
                    _currentNumber++;
                    _timeLifeText = HistoreTime;
                    _dialogue = false;
                    Action(_currentNumber);
                }    
            }
            if (!_dialogue)
            {
                _uiText.text = null;
                if (_currentNumber >= _maxNumber) 
                {
                    print("Диалог завершён");
                    _currentNumber = 1;
                }
            }
            
        }
        [Serializable]
        public class Stages
        {
            [SerializeField] private int _numberStage;
            [SerializeField] private string _text;
            [SerializeField] private float timeLifeText;
            [SerializeField] private UnityEvent _action;

            public int NumberStage => _numberStage;
            public string Text => _text;
            public float TimeLifeText => timeLifeText;
            public UnityEvent Action => _action;
        }

    }
}

