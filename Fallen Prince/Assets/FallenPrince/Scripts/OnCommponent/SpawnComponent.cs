using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace FallenPrice.Component
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private UnityEvent _action;
        [SerializeField] private NewPosition[] _SpawnPositions;
        [SerializeField] private Vector2 MousePosition;
        private int _currentPositions;

        public void SetSpawn(String Name)
        {
            for (int i = 0; i < _SpawnPositions.Length; i++)
            {
                if(_SpawnPositions[i].Name == Name)
                {
                    print(Name);
                    _currentPositions = i;
                    SpawnByName();
                }
            }
        }
        public void Spawn()
        {
            Instantiate(_prefab, _spawnPosition.position, transform.rotation);
            if (_action != null) _action.Invoke();
        }
        public void SetActiveThisPrefab()
        {
            if(_prefab != null)
            {
                _prefab.SetActive(true);
            } 
            
        }
        private void FixedUpdate()
        {
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        private void SpawnByName()
        {
            var Positions = _SpawnPositions[_currentPositions];
            if (Positions.SpawnAtMouse)
            {
                Instantiate(Positions.Prefab, MousePosition, transform.rotation);
            }

            if(!Positions.SpawnAtMouse)
            {
                Instantiate(Positions.Prefab, Positions.SpawnPosition.position, transform.rotation);
            }
            if (Positions.Action != null) Positions.Action.Invoke();
           // Positions.Prefab.transform.position = Positions.SpawnPosition.position;
        }
        public void SpawnReceivedObject(GameObject Prefab)
        {
            Instantiate(Prefab, transform.position, transform.rotation);
            Prefab.transform.position = transform.position;
        }
    }

    

    [Serializable]

    public class NewPosition
    {
        [SerializeField] private string _Name;
        [SerializeField] private Transform _SpawnPosition;
        [SerializeField] private bool _SpawnAtMouse;
        [SerializeField] private GameObject _Prefab;
        [SerializeField] private UnityEvent _Action;

        public string Name => _Name;
        public Transform SpawnPosition => _SpawnPosition;
        public bool SpawnAtMouse => _SpawnAtMouse;
        public GameObject Prefab => _Prefab;
        public UnityEvent Action => _Action;
    }
}

