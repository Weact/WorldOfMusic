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
    } 
}


