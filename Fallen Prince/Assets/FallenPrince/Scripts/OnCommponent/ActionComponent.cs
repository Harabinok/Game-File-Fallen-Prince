using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FallenPrice.GameSetting;

namespace FallenPrice.Component
{
    public class ActionComponent : MonoBehaviour
    {
        private ManagementGameSettings managementGameSettings;
        [SerializeField] private UnityEvent _action;

        private void Awake()
        {
            managementGameSettings = FindObjectOfType<ManagementGameSettings>();
        }
        private void Update()
        {
            var KeyAction = managementGameSettings.Interactable;
            if (Input.GetKeyDown(KeyAction))
            {
                if(_action!= null)
                {
                    _action.Invoke();
                }
            }
        }
    }
}

