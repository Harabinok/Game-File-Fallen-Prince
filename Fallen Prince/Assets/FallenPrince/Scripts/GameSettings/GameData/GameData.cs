using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace FallenPrice.GameSetting.GameData
{
    [Serializable]
    public class GameData : MonoBehaviour
    {
        public int Hp;
        public int Mana;
        public int Coin;

        public bool Pause;
    }

}
