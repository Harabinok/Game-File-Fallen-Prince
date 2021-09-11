using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenPrice.GameSetting;
using FallenPrice.UICommponent;

namespace FallenPrice
{
    public class PlayerInput : MonoBehaviour
    {
        Player _player;
        AbilitiesMannager _abilitiesMannager;
        ManagementGameSettings _managementGameSettings;
        private bool OpenMenu = false;
        private bool _selectAbilitiesOneClike = false;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _abilitiesMannager = FindObjectOfType<AbilitiesMannager>();
            _managementGameSettings = FindObjectOfType<ManagementGameSettings>();
        }



        private void Update()
        {
            ///ManagamentGamaSettings///
            var Attack = _managementGameSettings.Attack;

            var Interactable = _managementGameSettings.Interactable;
            ///ManagamentGamaSettings///

            ////////////////MOVEMENT////////////////////////
            if (!OpenMenu)
            {
                var Horizontal = Input.GetAxis("Horizontal");
                var Vertical = Input.GetAxis("Vertical");
                _player.SetDirection(Horizontal, Vertical);
            }
            ///////////////MOVEMENT/////////////////////////

            ///////////////Attack///////////////////////////
            if (Input.GetKeyDown(Attack) && !OpenMenu)
            {
                _player.Attack();

            }

            ///////////////Attack///////////////////////////

            ///////////////Abilities////////////////////////
            if (Input.GetKeyDown(KeyCode.I))
            {
                OpenMenu = !OpenMenu;
                if (!OpenMenu)
                {
                    _player.OpenFire(true);
                }
                else
                {
                    _player.OpenFire(false);
                }
                _abilitiesMannager.AbilitiesMannagerUI();

            }
            ///////////////Abilities////////////////////////

            /////////////////Interactable/////////////////////
            if (Input.GetKeyDown(Interactable))
            {
                _player.Interactable();
            }
            /////////////////Interactable/////////////////////
        }
        public void MenuOpen()
        {
            OpenMenu = !OpenMenu;
        }
    }
}

