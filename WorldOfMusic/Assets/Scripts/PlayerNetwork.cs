using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;


public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField]
    private NetworkObject _networkObject;
    [SerializeField]
    private GameObject cam;  
    public float Gravity = -15.0f;
    void Update(){
        
    if (_networkObject.IsOwner){
    
    Vector3 position = new Vector3(0, 0, 0);
    if (Input.GetKey(KeyCode.Z)){
        position.z += 1f;
    }
    if (Input.GetKey(KeyCode.S)){
        position.z -= 1f;
    }
    if (Input.GetKey(KeyCode.Q)){
        position.x -= 1f;
    }
    if (Input.GetKey(KeyCode.D)){
        position.x += 1f;
    }
    transform.position += position * Time.deltaTime * 5f;
    cam.SetActive(true);
    }
    else{
        cam.SetActive(false);
    }

}
}

