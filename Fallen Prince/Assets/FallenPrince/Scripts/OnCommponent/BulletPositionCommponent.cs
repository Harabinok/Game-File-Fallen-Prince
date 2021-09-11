using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenPrice.Component
{
    public class BulletPositionCommponent : MonoBehaviour
    {
        [SerializeField] bool _TrackPosition;
        [SerializeField] private Vector2 _gameObjectPosition;
        private Vector2 _defaultPosition;
        
        private void Awake()
        {
            _defaultPosition = transform.position;
        }
        public void TrackAPosition(bool TrackPosition)
        {
            _TrackPosition = TrackPosition;
        }

        private void Update()
        {
            if (_TrackPosition)
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _gameObjectPosition = transform.position;
            }
            
        }
    }
}

