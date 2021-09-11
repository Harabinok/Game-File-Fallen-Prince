using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenPrice.GameSetting.AI;
using System.Linq;
using FallenPrice.GameSetting;

namespace FallenPrice.Model
{
    public class UnitData : MonoBehaviour
    {

        [Header("Player")]
        public GameObject Player;


        [Header("Enemy")]
        public GameObject[] Enemy;

        [Header("Friend Unit")]
        public GameObject[] Friend;

        SaveGameData _saveGameData;
        private void Awake()
        {
           
            Player = GameObject.FindGameObjectWithTag("Player");
            Friend = GameObject.FindGameObjectsWithTag("Friend");
            Enemy = GameObject.FindGameObjectsWithTag("Enemy");

            _saveGameData = FindObjectOfType<SaveGameData>();
        }
        



        public void NewUnit()
        {
            Enemy = new GameObject[0];
            Friend = new GameObject[0];
            Invoke("UnidUpdate", 0.000001f);
        }
        void UnidUpdate()
        {
            Enemy = GameObject.FindGameObjectsWithTag("Enemy");
            Friend = GameObject.FindGameObjectsWithTag("Friend");
            NumberOfEnemies = Enemy.Length;
            NumberOfFriend = Friend.Length;
            


        }
       public int NumberOfEnemies;
        public int NumberOfFriend;
        private void Start()
        {
            NumberOfEnemies = Enemy.Length;
            NumberOfFriend = Friend.Length;
        }
    }
}


