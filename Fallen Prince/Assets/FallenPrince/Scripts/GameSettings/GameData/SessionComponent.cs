using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenPrice.GameSetting.GameData
{
    public class SessionComponent : MonoBehaviour
    {
        [SerializeField] private PlayerData _gameData;
        public PlayerData GamaData => _gameData;

        private void Awake()
        {
            if (IsSession())
            {
                print(false);
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
            }
        }

        private bool IsSession()
        {
            var Session = FindObjectsOfType<SessionComponent>();
            foreach (var gameData in Session)
            {
                if (gameData != this)
                    return true;
                
            }
            return false;
        }

        public void PauseGame(bool _Pause)
        {
            GamaData.Pause = _Pause;
            if (_Pause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        private void Update()
        {
            PauseGame(GamaData.Pause);
        }
        private void FixedUpdate()
        {
        }

    }
}


