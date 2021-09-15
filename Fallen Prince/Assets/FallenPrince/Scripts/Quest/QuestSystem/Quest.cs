using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using FallenPrice.GameSetting;

namespace FallenPrice.QuestSystem
{
    public class Quest : MonoBehaviour
    {
        [SerializeField] private string _nameQuest;

        [SerializeField] public bool Active;

        [SerializeField] public GameObject ProgressQuest;

        [SerializeField] private GameObject Progress;

        [SerializeField] private Text _nameQuestUi;

        [SerializeField] private UnityEvent _OnStartQuest;

        private void Awake()
        {
            gameObject.tag = "Quest";
            gameObject.SetActive(true);
        }
        private void Start()
        {
            
            if (!Active)
            {
                gameObject.SetActive(false);
            }
            else
            {

            }
            
        }
        public void StartQuest()
        {
            Active = true;
            _nameQuestUi.text = $"{_nameQuest}";
            gameObject.SetActive(true);
            _OnStartQuest?.Invoke();
        }
        public void EndQuest()
        {
            Active = false;
            Destroy(gameObject);
        }

        public void LoadSave(Save.QuestSaveData save)
        {
           
        }
    }
}

