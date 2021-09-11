using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FallenPrice.GameSetting.AI
{
    public class NavMash : MonoBehaviour
    {
        public Transform _Player;
        NavMeshAgent agent;
        public float Speed;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }

        private void Update()
        {
           agent.SetDestination(_Player.position);
        }
    }
}

