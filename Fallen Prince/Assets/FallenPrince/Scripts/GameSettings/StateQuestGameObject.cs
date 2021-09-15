using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenPrice.GameSetting
{
    public class StateQuestGameObject : MonoBehaviour
    {
        public enum state {Destroy, Inactive, Active };
        public state State;
          public int _state = 0;


        private void Awake()
        {
           
        }
        private void Start()
        {
            if (State == state.Destroy)
            {
                _state = 0;
            }
            if (State == state.Inactive)
            {
                _state = 1;
            }
            if (State == state.Active)
            {
                _state = 2;
            }
            ActiveState();
        }
        private void ActiveState()
        {
            
                if (_state == 0)
                {
                    State = state.Destroy;
                    Destroy(gameObject);
                }
                if (_state == 1)
                {
                    State = state.Inactive;
                    gameObject.SetActive(false);
                }
                if (_state == 2)
                {
                    State = state.Active;
                    gameObject.SetActive(true);
                }
            
            
        }

        public void SetActiveFalse()
        {
            _state = 1;
            State = state.Inactive;
            gameObject.SetActive(false);
        }

        public void SetActiveTrue()
        {
            _state = 2;
            State = state.Active;
            gameObject.SetActive(true);
        }
        public void LoadSave(Save.QuestSaveData save)
        {
            print("Hi");
            _state = save.Progress.StateActive;
            ActiveState();
        }
    }
}

