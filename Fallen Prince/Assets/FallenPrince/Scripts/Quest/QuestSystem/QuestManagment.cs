using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FallenPrice.QuestSystem
{
    public class QuestManagment : MonoBehaviour
    {
        [SerializeField] private Quests[] _quests;

        public void SetQuest(String NameQuest)
        {
            for (int i = 0; i < _quests.Length; i++)
            {
                if(_quests[i].NameQuest == NameQuest)
                {
                    _quests[i].Quest.StartQuest();
                }
            }
        }
    }
    [Serializable]
    public class Quests
    {
        [SerializeField] private string _nameQuest;
        [SerializeField] private Quest _quest;

        public string NameQuest => _nameQuest;
        public Quest Quest => _quest;
    }
}

