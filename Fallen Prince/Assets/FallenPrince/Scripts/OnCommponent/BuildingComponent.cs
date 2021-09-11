using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace FallenPrice.Component
{
    public class BuildingComponent : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool _MyBuilding;
        public enum Shop { None, Barrack };
        public Shop _shop;
        [Header("UI")]
        [SerializeField] private GameObject Uimenu;
        [SerializeField] private GameObject Menu;
        SpriteRenderer _spriteRender;

        private void Awake()
        {
            _spriteRender = GetComponent<SpriteRenderer>();
        }

        public void ShopAction()
        {
            if(_MyBuilding)
            {
                if (_MyBuilding && Uimenu != null)
                {
                    Uimenu.SetActive(true);
                    Menu.SetActive(true);
                }
                
            }
            
        }

        public void Quit()
        {
            Uimenu.gameObject.SetActive(false);
            Menu.SetActive(false);
        }
        public void Capture()
        {
            _MyBuilding = true;
            _spriteRender.color = Color.blue;
        }

    }
}

