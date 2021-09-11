using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FallenPrice.Component
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent FireBall;
        [SerializeField] private UnityEvent Resurrection;

        public void SetAbilities(string Name)
        {
           if(Name == "Fire Ball")
            {
                if (FireBall != null)
                {
                    FireBall.Invoke();
                }
            }
            
           if (Name == "Resurrection")
            {
                if (Resurrection != null)
                {
                    Resurrection.Invoke();
                }
            }
        }
    }
}

