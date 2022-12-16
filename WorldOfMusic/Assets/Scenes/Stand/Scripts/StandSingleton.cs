using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StandSingleton : MonoBehaviour
{
    private static StandSingleton instance;
    public string standJson;
    public bool updated = false;

    public static StandSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StandSingleton>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetStandJson(string json)
    {
        standJson = json;
        updated = true;
    }
    public void OpenEditorScene()
    {
        SceneManager.LoadScene("Scenes/Stand/StandScene");
    }
}
