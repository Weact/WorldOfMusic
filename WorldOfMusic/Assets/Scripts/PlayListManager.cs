using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class PlayListManager : MonoBehaviour
{


    public AudioSource m_AudioSource;
    

    [Serializable]
    public struct MusicList
    {
        public string nom;
        public Sprite image;
        public string description;
        public AudioClip music;
        public int index;

    }
    [SerializeField] MusicList[] musiclist;

    
    
    public AudioClip[] listMusique;
    
    void Start()
    {
       
       m_AudioSource= GetComponent<AudioSource>();
      

        GameObject ButMusic = transform.GetChild(0).gameObject;
        GameObject g;
        
    int N = musiclist.Length;


        for (int i = 0; i < N; i++)
        {
            musiclist[i].index = i ;
            g = Instantiate(ButMusic, transform);    
            g.transform.GetChild(0).GetComponent<Image>().sprite = musiclist[i].image;
            g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = musiclist[i].nom;
            g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = musiclist[i].description;
            g.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = musiclist[i].index.ToString();

            listMusique[i]= musiclist[i].music;
            g.GetComponent<Button>().onClick.AddListener(() => PlayMusic(i));
            
            

        }
        Destroy(ButMusic);   
    }

    public void PlayMusic(int k)
    {

       
         m_AudioSource.clip = listMusique[k];
         m_AudioSource.Play();
    }

}