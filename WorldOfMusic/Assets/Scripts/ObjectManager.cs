using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject Panellum;
    public GameObject PanelStruct;
    public GameObject PanelDj;
    public GameObject PanelEffet;

    // Start is called before the first frame update
    void Start()
    {
        Panellum.SetActive(true);
        PanelStruct.SetActive(false);
        PanelDj.SetActive(false);
        PanelEffet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanelLum()
    {
        Panellum.SetActive(true);
        PanelStruct.SetActive(false);
        PanelDj.SetActive(false);
        PanelEffet.SetActive(false);
    }

    public void PanelStruc()
    {
        Panellum.SetActive(false);
        PanelStruct.SetActive(true);
        PanelDj.SetActive(false);
        PanelEffet.SetActive(false);
    }

    public void PanelDJ()
    {
        Panellum.SetActive(false);
        PanelStruct.SetActive(false);
        PanelDj.SetActive(true);
        PanelEffet.SetActive(false);
    }

    public void PanelEff()
    {
        Panellum.SetActive(false);
        PanelStruct.SetActive(false);
        PanelDj.SetActive(false);
        PanelEffet.SetActive(true);
    }
}
