using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FallenPrice.GameSetting.AI;

namespace FallenPrice.QuestSystem.Component
{
    public class ArrayEnemyQuestComponent : MonoBehaviour
    {
        private Transform[] _targets;
        [SerializeField] private UnityEvent _action;

        private void Update()
        {
            _targets = GetComponentsInChildren<Transform>();
            if (_targets.Length <= 1)
            {
                if(_action != null)
                {
                    _action.Invoke();
                }
            }
        }
    }
}

