using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class PlayerNetwork : NetworkBehaviour
{
/*    private InputPlayer playerinputAction;
    private InputAction movement;

    private void Awake(){
        playerinputAction = new InputPlayer();
    }
    private void OnEnable (){
        movement = playerinputAction.PlayerMap.HautBas;
        movement.Enable();
        

        playerinputAction.PlayerMap.Jump.performed += DoJump;
        playerinputAction.PlayerMap.Jump.Enable();
    }
    private void OnDisable(){
        movement.Disable();
        playerinputAction.PlayerMap.Jump.Disable();
    }
    private void DoJump(InputAction.CallbackContext context){
    Debug.Log("Jump");
    }
    private void FixedUpdate(){
    Debug.Log("Mouvement Values" + movement.ReadValue<Vector2>()); // Vector2(0,0)
    }
    private void Update(){
    if(!IsOwner){
        return;
    }
   // var input = InputPlayer.current;
   
    if (input == null) return;
    Vector3 position = new Vector3(0, 0, 0);
    movement= PlayerNetwork.inputAction.PlayerMap.Mouvement;

    if (Input.GetKey(KeyCode.S)){
        position.z -= 1f;
    }
    
    if (input.UpDown.value>0){
        position.z += 1f;
        Debug.Log("Z");
    }else if (input.UpDown.value<0){
        position.z -= 1f;
        Debug.Log("S");
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
   
    float movespeed = 3f;

    transform.position += movement * movespeed * Time.deltaTime;
    
}
*/ 
}

