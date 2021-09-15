using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using FallenPrice.Model;
using System;

namespace FallenPrice.UICommponent
{
    public class DialogueUIComponent : MonoBehaviour
    {
        [SerializeField] private GameObject DialogueUI;
        [SerializeField] private Text _uiText;
        [SerializeField] private Image _uiAvatar;
        [SerializeField] private float _timeLifeText;

        [SerializeField] private Stages[] _stages;
        [SerializeField] private bool _dialogue;
        private int _currentStage;
        private int _currentNumber = 0;
        private int _maxNumber;

        private void Awake()
        {
            _currentStage = _stages.Length;
        }
        public void Action(int Number)
        {
            DialogueUI.SetActive(true);
            for (int i = 0; i < _stages.Length; i++)
            {
                if (!_dialogue)
                {
                    if (_stages[i].NumberStage == Number)
                    {
                        _dialogue = true;
                        _currentStage = i;
                        HistoreTime = _stages[i].TimeLifeText;
                        _timeLifeText = HistoreTime;
                        _uiAvatar.sprite = _stages[i].Avatar;
                        _uiText.text = $"{_stages[i].Text}";
                        
                        if (_stages[i].Action != null)
                        {
                            _stages[i].Action.Invoke();
                        }
                    }
                }
                
            }
        }

        private float HistoreTime;
        private void Update()
        {
            if (_dialogue)
            {

                _timeLifeText -= Time.unscaledDeltaTime;
                if (_timeLifeText <= 0)
                {
                    _currentNumber++;
                    _timeLifeText = HistoreTime;
                    _dialogue = false;
                    Action(_currentNumber);
                }
            }
            if (!_dialogue)
            {
                
                if (_currentNumber >= _maxNumber)
                {
                    _currentNumber = 1;
                }
            }
        }

        public void EndDialogue()
        {
            DialogueUI.SetActive(false);
            _dialogue = false;
        }

        public void Skip()
        {
            _timeLifeText = 0;
        }

        [Serializable]
        public class Stages
        {
            [SerializeField] private int _numberStage;
            [SerializeField] private Sprite _avatar;
            [SerializeField] private string _text;
            [SerializeField] private float timeLifeText;
            [SerializeField] private UnityEvent _action;

            public int NumberStage => _numberStage;
            public string Text => _text;
            public Sprite Avatar => _avatar;
            public float TimeLifeText => timeLifeText;
            public UnityEvent Action => _action;
        }
    }
}

