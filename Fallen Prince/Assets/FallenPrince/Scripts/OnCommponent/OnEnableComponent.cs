using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FallenPrice.Component
{
    public class OnEnableComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _OnEnable;
        private void OnEnable()
        {
            _OnEnable?.Invoke();
        }
    }
}

