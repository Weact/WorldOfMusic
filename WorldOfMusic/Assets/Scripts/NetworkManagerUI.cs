using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button ServerBut;
    [SerializeField] private Button HostBut;
    [SerializeField] private Button ClientBut;
    [SerializeField] private Button Droite;
    [SerializeField] private Button Gauche;
    [SerializeField] private Button Fan;
    [SerializeField] private Button Artiste;
    [SerializeField] private Canvas _canvas;
    public int color = 0;
    public int TailleTableau = 3;
    public int User = 0;

    private void Awake(){
    ServerBut.onClick.AddListener(() => {
        NetworkManager.Singleton.StartServer();
    });
   HostBut.onClick.AddListener(() => {
        NetworkManager.Singleton.StartHost();
        _canvas.enabled = false;
    });
    ClientBut.onClick.AddListener(() => {
        NetworkManager.Singleton.StartClient();
        _canvas.enabled = false;
    });
    Droite.onClick.AddListener(() => {
        color++;
        if(color<0){
            color = TailleTableau;
        }
        if(color>TailleTableau){
            color = 0;
        }
    });
    Gauche.onClick.AddListener(() => {
        color--;
        if(color<0){
            color = TailleTableau;
        }
        if(color>TailleTableau){
            color = 0;
        }
    });
    
    Fan.onClick.AddListener(() => {
        User = 1;
    });
    Artiste.onClick.AddListener(() => {
        User = 2;
    });
    } 
    


}


