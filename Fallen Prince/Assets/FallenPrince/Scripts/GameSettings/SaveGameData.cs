using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using FallenPrice;
using FallenPrice.GameSetting.AI;
using FallenPrice.Model;

namespace FallenPrice.GameSetting
{
    public class SaveGameData : MonoBehaviour
    {
        [HideInInspector] public List<GameObject> EnemySave = new List<GameObject>();
        [HideInInspector] public List<GameObject> FriendSave = new List<GameObject>();
        [HideInInspector] public List<GameObject> PlayerSave = new List<GameObject>();
        UnitData _unitData;
        string filePath;
        [SerializeField] private bool SavePlayer;
        [SerializeField] private bool SaveUnit;

        private void Awake()
        {
            _unitData = FindObjectOfType<UnitData>();
           
        }
        private void Start()
        {
            for (int i = 0; i < _unitData.Enemy.Length; i++)
            {
                EnemySave.Add(_unitData.Enemy[i]);
            }
            for (int i = 0; i < _unitData.Friend.Length; i++)
            {
                FriendSave.Add(_unitData.Friend[i]);
            }
            for (int i = 0; i < 1; i++)
            {
                PlayerSave.Add(_unitData.Player);
            }
                
            

            filePath = Application.persistentDataPath + "/Save.GameSaveData";
            LoadGame();
        }
        private void OnApplicationQuit()
        {
            SaveGame();
        }

        public void SaveGame()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filePath, FileMode.Create);

            Save save = new Save();
            if (SaveUnit)
            {
                save.SaveEnemys(EnemySave);
                save.SaveFriend(FriendSave);
            }

            if (SavePlayer)
            {
                save.SavePlayer(PlayerSave);
            }
            

            bf.Serialize(fs, save);
            fs.Close();
        }

        public void LoadGame()
        {
            if (!File.Exists(filePath))
                return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filePath, FileMode.Open);

            Save save = (Save)bf.Deserialize(fs);
            fs.Close();

            int Player = 0;
            int Enemy = 0;
            int Friend = 0;

            foreach (var enemy in save.EnemyData)
            {
                EnemySave[Enemy].GetComponent<AIEnemy>().LoadSave(enemy);
                Enemy++;
            }
            foreach (var friend in save.FriendData)
            {
                FriendSave[Friend].GetComponent<AIFriend>().LoadSave(friend);
                Friend++;
            }
            foreach (var player in save.PlayerData)
            {
                PlayerSave[Player].GetComponent<Player>().LoadSave(player);
                Player++;
            }
            
        }


    }
    [System.Serializable]
    public class Save
    {
        [System.Serializable]
        public struct Vec3
        {
           public float x, y, z;

            public Vec3(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
        [System.Serializable]
        public struct PlayerSaveData
        {
            public Vec3 Position;

           public PlayerSaveData(Vec3 Pos)
            {
                Position = Pos;
            }
        }
        public List<PlayerSaveData> PlayerData =
            new List<PlayerSaveData>();

        public void SavePlayer(List<GameObject> player)
        {
            foreach (var go in player)
            {
                Vec3 Pos = new Vec3(go.transform.position.x, go.transform.position.y, go.transform.position.z);
                PlayerData.Add(new PlayerSaveData(Pos));
            }
        }

        [System.Serializable]
        public struct EnemySaveData
        {
           public Vec3 Position;

            public EnemySaveData(Vec3 Pos)
            {
                Position = Pos;
            }
        }
        public new List<EnemySaveData> EnemyData 
            = new List<EnemySaveData>();



        public void SaveEnemys(List<GameObject> enemies)
        {
            foreach (var go in enemies)
            {
                Vec3 Pos = new Vec3(go.transform.position.x, go.transform.position.y, go.transform.position.z);
                EnemyData.Add(new EnemySaveData(Pos));
            }
        }

        [System.Serializable]
        public struct FriendSaveData
        {
            public Vec3 Position;

            public FriendSaveData(Vec3 Pos)
            {
                Position = Pos;
            }
        }
        public new List<FriendSaveData> FriendData
    = new List<FriendSaveData>();
        public void SaveFriend(List<GameObject> friend)
        {
            foreach (var go in friend)
            {
                Vec3 Pos = new Vec3(go.transform.position.x, go.transform.position.y, go.transform.position.z);
                FriendData.Add(new FriendSaveData(Pos));
            }
        }
    }
}

