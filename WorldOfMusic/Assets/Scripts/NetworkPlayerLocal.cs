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
    
    // Start is called before the first frame update
    void Start()
    {
        if (_networkObject.IsOwner)
        {
            _material.material.color = Color.red;
            _camera.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
