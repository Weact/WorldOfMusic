using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class ServerManager : MonoBehaviour
{    
    [SerializeField]
    private NetworkObject _networkObject;
    public bool bServeur = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!_networkObject)
            _networkObject = GetComponent<NetworkObject>();
        
        
        if (bServeur)
        {
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
            NetworkManager.Singleton.StartServer();
        }
        else
        {
            NetworkManager.Singleton.StartClient();
        }
    }

    void OnClientConnected(ulong clientId)
    {
        Debug.Log("Client connected: " + clientId);
    }
    
    void OnClientDisconnected(ulong clientId)
    {
        Debug.Log("Client disconnected: " + clientId);
    }

    // Update is called once per frame
    void Update()
    {

        if (!_networkObject)
        {
            if (Input.GetKeyDown("T"))
            {
                if (SceneManager.GetActiveScene().name == "ServeurClientTest")
                {
                    SceneManager.LoadScene("ServeurClientTest2");
                }
                else
                {
                    SceneManager.LoadScene("ServeurClientTest");
                }
            }
        }
    }
}
