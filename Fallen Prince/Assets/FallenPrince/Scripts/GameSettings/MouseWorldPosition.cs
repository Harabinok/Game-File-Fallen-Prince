using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenPrice.GameSetting
{
    public class MouseWorldPosition : MonoBehaviour
    {
        [SerializeField] bool _TrackPosition;
        [SerializeField] private Vector2 _mousePosition;
        

        public void TrackAPosition(bool TrackPosition)
        {
            _TrackPosition = TrackPosition;
        }

        private void Update()
        {
            if (_TrackPosition)
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _mousePosition = transform.position;
            }

        }
    }
}

