using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class PlayListManager : MonoBehaviour
{
    [Serializable]
    public struct MusicList
    {
        public string nom;
        public Sprite image;
        public string description;
        public AudioSource music;

    }
    [SerializeField] MusicList[] musiclist;




    void Start()
    {
       


        GameObject ButMusic = transform.GetChild(0).gameObject;
        GameObject g;
        
        int N = musiclist.Length;

        for (int i = 0; i < N; i++)
        {
           
            g = Instantiate(ButMusic, transform);
            g.SetActive(true);
            g.transform.GetChild(0).GetComponent<Image>().sprite = musiclist[i].image;
            g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = musiclist[i].nom;
            g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = musiclist[i].description;
           

            Destroy(ButMusic);
        }
    }

 

}