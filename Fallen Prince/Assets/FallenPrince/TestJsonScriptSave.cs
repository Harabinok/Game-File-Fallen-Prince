using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJsonScriptSave : MonoBehaviour
{
    public Object[] GameObjects;
    public Object[] GameObjects2;

    public void Save()
    {
        PlayerPrefs.SetString("SecretKey007", JsonUtility.ToJson(GameObjects));
    }

    public void Load()
    {
        GameObjects2 = JsonUtility.FromJson<GameObject[]>(PlayerPrefs.GetString("SecretKey007"));
    }
}
