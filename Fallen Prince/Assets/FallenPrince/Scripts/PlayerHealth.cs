using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace FallenPrice
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] public int Health;
        [SerializeField] private Slider LineHealth;
        [SerializeField] private Text HealthText;
        [SerializeField] private UnityEvent OnDamage;
        [SerializeField] private UnityEvent OnDia;

        private void Awake()
        {
            LineHealth.maxValue = Health;
            
        }


        private void FixedUpdate()
        {
            HealthText.text = $"{Health}  /  {LineHealth.maxValue}";
            if (Input.GetKeyDown(KeyCode.E))
            {
                Health -= 10;
            }
            LineHealth.value = Health;
            if(Health <= 0)
            {
                Health = 0;
            }
        }
        public void DamageCaused(int Damage)
        {
            Health -= Damage;
            if(OnDamage != null)
            {
                OnDamage.Invoke();
            }
            if(Health <= 0)
            {
                Health = 0;
                LineHealth.value = 0;
                HealthText.text = $"{0}  /  {LineHealth.maxValue}";
                if (OnDia != null)
                {
                    OnDia.Invoke();
                    
                }
                
            }

        }
        public void Dia()
        {
            Destroy(gameObject);
        }
    }
}

