using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ObjectManager : MonoBehaviour
{
   



    public GameObject PanelAccessoires;
    public GameObject PanelStruct;
 
    void Start()
    {
        PanelStruct.SetActive(true);
        PanelAccessoires.SetActive(false);


       


    }

    
    void Update()
    {
        
    }
    public void PanelStruc()
    {
        PanelStruct.SetActive(true);
        PanelAccessoires.SetActive(false);
    }

    public void PanelAccs()
    {
        PanelStruct.SetActive(false);
        PanelAccessoires.SetActive(true);
    }


  
}
