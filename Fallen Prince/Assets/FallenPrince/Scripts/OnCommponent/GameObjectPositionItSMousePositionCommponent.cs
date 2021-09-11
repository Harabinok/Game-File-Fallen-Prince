using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FallenPrice.Component
{
    public class GameObjectPositionItSMousePositionCommponent : MonoBehaviour
    {
        [SerializeField] private Transform Prefab;
        private bool MousePosition = true;
        [SerializeField] Camera _camera;

        private void Update()
        {
            if(MousePosition)
            Prefab.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Prefab.transform.position = new Vector3(Prefab.position.x, Prefab.position.y, 0);
        }
        public void StartPositionMouse()
        {
            MousePosition = true;
        }
        public void StopPositionMouse()
        {
            MousePosition = false;
        }
    }
}

