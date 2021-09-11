using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace FallenPrice.Component
{
    public class OnTriggerComponnent : MonoBehaviour
    {
        [SerializeField] private float _timeAction;
        [SerializeField] private Object[] _object;
        private void OnTriggerEnter2D(Collider2D collider)
        {
            for (int i = 0; i < _object.Length; i++)
            {
                var CurrentObject = _object[i];
                if (collider.gameObject.CompareTag(CurrentObject.Tag))
                {
                    if (CurrentObject.Action != null)
                    {
                        CurrentObject.Action.Invoke();
                    }
                }
            }
            
        }
    }
    [Serializable]
    public class Object
    {
        [SerializeField] private string _tag;
        [SerializeField] private UnityEvent _action;

        public string Tag => _tag;
        public UnityEvent Action => _action;
    }
}

 