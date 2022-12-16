using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonGoToScene : MonoBehaviour
{
    private void Start()
    {
        Button btn = this.GetComponent<Button>();
        this.GetComponent<Button>().onClick.AddListener(() => goToEditor());
    }

    public void goToEditor()
    {
        SceneManager.LoadScene("Scenes/Stand/StandScene");
    }
}
