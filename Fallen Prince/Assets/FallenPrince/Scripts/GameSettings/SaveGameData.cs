using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using FallenPrice;
using FallenPrice.GameSetting.AI;
using FallenPrice.Model;
using FallenPrice.QuestSystem;

namespace FallenPrice.GameSetting
{
    public class SaveGameData : MonoBehaviour
    {
        [HideInInspector] public List<GameObject> EnemySave = new List<GameObject>();
         public List<GameObject> FriendSave = new List<GameObject>();
         public List<GameObject> PlayerSave = new List<GameObject>();
        public List<GameObject> QuestSave = new List<GameObject>();
        Model.GameData _gameData;
        string filePath;
        [SerializeField] private bool SavePlayer;
        [SerializeField] private bool SaveUnit;

        [SerializeField] public GameObject _testGameObject;

        private void Awake()
        {

            _gameData = FindObjectOfType<Model.GameData>();
           
        }
        private void Start()
        {
            filePath = Application.persistentDataPath + "/Save.GameSaveDataTEST";
          // LoadGame();
        }
        private void OnApplicationQuit()
        {
            //SaveGame();
        }

        public void SaveGame()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filePath, FileMode.Create);

            Save save = new Save();

            save.SaveQuest(QuestSave);
            save.SavePlayer(PlayerSave);


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

            int _Quest = 0;
            int _Player = 0;

            foreach (var _quest in save.QuestData)
            { 
                QuestSave[_Quest].GetComponent<StateQuestGameObject>().LoadSave(_quest);
                _Quest++;
            }

            foreach (var _player in save.PlayerData)
            {
                PlayerSave[_Player].GetComponent<Player>().LoadSave(_player);
                _Player++;
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
        public struct GameObj
        {
            public int StateActive;
         

            public GameObj(int _state )
            {
                StateActive = _state;
                
            }
        }
        [System.Serializable]
        public struct QuestSaveData
        {
            public GameObj Progress;

            public QuestSaveData(GameObj _quest)
            {
                Progress = _quest;
            }
        }
        public List<QuestSaveData> QuestData = new List<QuestSaveData>();

        public void SaveQuest(List<GameObject> _Quest)
        {
            foreach (var go in _Quest)
            {
                GameObj _progress = new GameObj(go.GetComponent<StateQuestGameObject>()._state);

                QuestData.Add(new QuestSaveData(_progress));
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
        public List<PlayerSaveData> PlayerData = new List<PlayerSaveData>();

        public void SavePlayer(List<GameObject> _player)
        {
            foreach (var go in _player)
            {
                Vec3 _position = new Vec3(go.transform.position.x, go.transform.position.y, go.transform.position.z);
                PlayerData.Add(new PlayerSaveData(_position));
            }
        }

    }
}

