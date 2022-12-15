using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


public class ButGenerator : MonoBehaviour
{
    public HUDScript HUD;
    [Serializable]
    public struct ObjetStructure
    {
        public string nom;
        public string description;
        public Sprite image;
        public GameObject prefab;
    }
    [SerializeField] ObjetStructure[] objstruct;

    
    void Start()
    {

        GameObject ButStruct = transform.GetChild(0).gameObject;
        GameObject g;
        int N = objstruct.Length;
        for (int i = 0; i < N; i++)
        {
            g = Instantiate(ButStruct, transform);
            g.transform.GetChild(0).GetComponent<Image>().sprite = objstruct[i].image;
            g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = objstruct[i].nom;
            g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = objstruct[i].description;
            g.transform.GetChild(3).GetComponent<buttonScript>().prefab = objstruct[i].prefab;
            g.GetComponent<Button>().onClick.AddListener(() => HUD.spawnElement(g));

        }

        Destroy(ButStruct);


    }

    
}
