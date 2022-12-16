using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class PlayListManager : MonoBehaviour
{

    public AudioSource audioSource;

  
    List<Song> favoriteSongs = new List<Song>();


    [System.Serializable]
    public class Song
    {
        public string name;
        public Sprite image;
        public string description;
        public AudioClip music;
        public int index;
    }


    public Song[] musicList;


    public Button buttonPrefab;

    void Start()
    {
        
        DisplayPlaylist();
    }

    
    public void DisplayPlaylist()
    {
        
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        
        for (int i = 0; i < musicList.Length; i++)
        {
            musicList[i].index = i;

            Button button = Instantiate(buttonPrefab, transform);
            button.transform.GetChild(0).GetComponent<Image>().sprite = musicList[i].image;
            button.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = musicList[i].name;
            button.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = musicList[i].description;
            button.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = musicList[i].index.ToString();

            
            Button favoriteButton = button.transform.GetChild(4).GetComponent<Button>();

            int index = i;
            button.onClick.AddListener(() => PlayMusic(index));
            favoriteButton.onClick.AddListener(() => AddToFavorites(index));
        }
    }

    
    public void DisplayFavorites()
    {
        
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        
        for (int i = 0; i < favoriteSongs.Count; i++)
        {
            Song song = favoriteSongs[i];
            Button button = Instantiate(buttonPrefab, transform);
           
            button.transform.GetChild(0).GetComponent<Image>().sprite = song.image;
            button.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = song.name;
            button.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = song.description;
            button.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = song.index.ToString();

            

            int index = i;
            button.onClick.AddListener(() => PlayMusic(index));
        }
    }


    public void PlayMusic(int index)
    {

        audioSource.clip = musicList[index].music;


        audioSource.Play();

        
        Song selectedSong = musicList[index];
        if (favoriteSongs.Contains(selectedSong))
        {
            favoriteSongs.Remove(selectedSong);
        }
        else
        {
            favoriteSongs.Add(selectedSong);
        }
    }

    
    public void AddToFavorites(int index)
    {
        Song selectedSong = musicList[index];
        if (favoriteSongs.Contains(selectedSong))
        {
            favoriteSongs.Remove(selectedSong);
        }
        else
        {
            favoriteSongs.Add(selectedSong);
        }
    }

    
    public void SwitchToFavorites()
    {
        
        DisplayFavorites();

        
        gameObject.SetActive(false);

        
        transform.parent.gameObject.SetActive(true);
    }

    
    public void SwitchToPlaylist()
    {
        
        DisplayPlaylist();

        
        transform.parent.gameObject.SetActive(false);

        
        gameObject.SetActive(true);
    }

    
}


