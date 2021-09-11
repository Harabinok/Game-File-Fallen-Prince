using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FallenPrice.GameSetting
{
    public class LoadScreen : MonoBehaviour
    {
        [SerializeField] private string LoadLevel;

        [SerializeField] private Slider _bar;

        [SerializeField] private GameObject ScreenLoad;

        public void load()
        {
            ScreenLoad.SetActive(true);
            StartCoroutine(LoadAsync());
        }

        IEnumerator LoadAsync()
        {
            AsyncOperation LoadAsync = SceneManager.LoadSceneAsync(LoadLevel);

            while (LoadAsync.isDone)
            {
                _bar.value = LoadAsync.progress;
                yield return null;
            }
        }

    }
}

