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
    [SerializeField] private Button Color1;
    [SerializeField] private Button Color2;
    public int color = 0;
    public int TailleTableau = 3;

    private void Awake(){
    ServerBut.onClick.AddListener(() => {
        NetworkManager.Singleton.StartServer();
    });
   HostBut.onClick.AddListener(() => {
        NetworkManager.Singleton.StartHost();
    });
    ClientBut.onClick.AddListener(() => {
        NetworkManager.Singleton.StartClient();
    });
    Color1.onClick.AddListener(() => {
        color += 1;
        if(color > TailleTableau){
        color = 0;
         }
        if(color < 0){
        color = TailleTableau;
        Debug.Log(color);
        }
    });
    Color2.onClick.AddListener(() => {
        color -= 1;
        if(color > TailleTableau){
        color = 0;
        }
        if(color < 0){
            color = TailleTableau;
            Debug.Log(color);
        }
    });
}
}


