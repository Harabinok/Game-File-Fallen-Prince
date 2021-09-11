using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenPrice.UICommponent;
using UnityEngine.Events;

namespace FallenPrice.GameSetting
{
    public class AbilitySelection : MonoBehaviour
    {
        [SerializeField] public string NameAbilities;
        [SerializeField] private float _restartAbilities;

        [SerializeField] private bool _exitMenu = false;

        [SerializeField] private Transform _posotionOutline;

        public GameObject Abilities;

        [SerializeField] PlayerInput _playerInput;

        [SerializeField] AbilitiesMannager _selectAbilities;

        [SerializeField] Player _player;
        [SerializeField] private UnityEvent _action;

        


        public void Select()
        {
            _posotionOutline.position = transform.position;
            _player.OpenFire(true);
            if (_exitMenu)
            {
                _playerInput.MenuOpen();
                _selectAbilities.ExitMenu();
            }
            _action?.Invoke();
            _player.Abilities(Abilities, _restartAbilities, NameAbilities);
        }
    }
}

