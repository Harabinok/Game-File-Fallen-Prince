using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace PixelCrew.Componnent
{
    public class OnTriggerComponnentt : MonoBehaviour
    {
        [SerializeField] private OnTriggerComponnent2[] _clips;
        private int _currentClip;
        String ClipsName;

        private void Update()
        {
         
        }
        private void Awake()
        {
            for (int i = 0; i < _clips.Length; i++)
            {
                if (_clips[i].Name == ClipsName)
                {
                    _currentClip = i;
                    
                }
            }
            Debug.Log(_currentClip);
        }
        public void SetClip()
        {
            
        }

            private void OnTriggerEnter2D(Collider2D collider)
        {

            var Clip = _clips[_currentClip];
            if (collider.gameObject.CompareTag(Clip.Tag))
            {
                if (Clip.Action != null)
                {
                    Clip.Action.Invoke();
                }
            }
        }
        [Serializable]

        public class OnTriggerComponnent2
        {
            [SerializeField] private string _name;
            [SerializeField] private string _tag;
            [SerializeField] private UnityEvent _action;

            public string Name => _name;
            public string Tag => _tag;
            public UnityEvent Action => _action;
        }
    }
    
    
}

 