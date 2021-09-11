using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenPrice.Abilites;

namespace FallenPrice.UICommponent
{
    public class AbilitiesMannager : MonoBehaviour
    {
        public Ball FireBall;
        public ResurrectionUndead Resurrection;
        public GameObject[] _abilities;
        [SerializeField] private GameObject AblitiesUI;
        float _direction;
        private bool Manneger = true;


        private void Awake()
        {

            

        }


        public void AbilitiesMannagerUI()
        {


            Manneger = !Manneger;


            if (!Manneger)
            {
                AblitiesUI.SetActive(true);
            }
            if (Manneger)
            {
                AblitiesUI.SetActive(false);


            }
        }

        public void ExitMenu()
        {
            Manneger = true;
            AblitiesUI.SetActive(false);
        }
    }
}

