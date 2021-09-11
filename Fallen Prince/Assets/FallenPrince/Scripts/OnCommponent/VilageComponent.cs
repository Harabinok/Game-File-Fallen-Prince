using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenPrice.Component
{
    public class VilageComponent : MonoBehaviour
    {
        public BuildingComponent[] _buildingComponent;

        private void Awake()
        {
            _buildingComponent = GetComponentsInChildren<BuildingComponent>();
        }

        public void Capture()
        {
            for (int i = 0; i < _buildingComponent.Length; i++)
            {
               var _Capture = _buildingComponent[i].GetComponent<BuildingComponent>();
                _Capture.Capture();
            }
        }
    }
}

