using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using FallenPrice;

namespace FallenPrice.Component
{
    public class BuyComponent : MonoBehaviour
    {
        public int Cost;
        public GameObject Prefab;
        [SerializeField] public Event _buy;
        public void Buy()
        {
         var player = FindObjectOfType<Player>();
            if(player._money < Cost)
            {
                print("Don't Money");
            }
            else
            {
                if(_buy != null)
                {
                    player._money -= Cost;
                    _buy.Invoke(Prefab);
                }
            }
        }
    }
    [Serializable]
    public class Event : UnityEvent<GameObject> { }
}

