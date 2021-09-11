using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FallenPrice.Component;

namespace FallenPrice.Component
{
    public class Interactable : MonoBehaviour
    {
       [SerializeField] private UnityEvent _action;
        public void Action()
        {

            if(CompareTag("Dialogue"))
            {
                if(_action != null)
                {
                    _action.Invoke();
                }
            }
            if (CompareTag("Village"))
            {
                if (_action != null)
                {
                   
                    _action.Invoke();
                }
            }
        }
    }

}
