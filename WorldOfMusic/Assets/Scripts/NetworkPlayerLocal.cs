using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayerLocal : MonoBehaviour
{
    //Code de test pour l'identification des bugs (local/distant)
    [SerializeField]
    private NetworkObject _networkObject;
    [SerializeField]
    private MeshRenderer _material;
    [SerializeField]
    private GameObject _camera;

    private NetworkData networkData;
    
    // Start is called before the first frame update
    void Start()
    {
        if (_networkObject.IsOwner)
        {
            _material.material.color = Color.red;
            _camera.SetActive(true);
            networkData = GameObject.FindObjectOfType<NetworkData>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_networkObject.IsOwner && Input.GetKeyDown(KeyCode.A))
        {
            if (networkData != null)
            {
                networkData.Incremente();
            }
            else
            {
                networkData = GameObject.FindObjectOfType<NetworkData>();
            }
        }
    }
}
