using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FallenPrice.Component
{
    public class LoadNextSceneComponent : MonoBehaviour
    {
       [SerializeField] private string NameNextScene;
        public void LoadScene()
        {
            SceneManager.LoadScene(NameNextScene);
        }
    }
}

