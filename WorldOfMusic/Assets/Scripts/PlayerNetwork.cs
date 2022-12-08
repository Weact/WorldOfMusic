using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class PlayerNetwork : NetworkBehaviour
{
    private InputPlayer playerinputAction;
    private InputAction movement;
    private Rigidbody rb;

    private void Awake(){
        playerinputAction = new InputPlayer();
    }
    private void OnEnable (){
        movement = playerinputAction.PlayerMap.HautBas;
        movement.Enable();
        playerinputAction.PlayerMap.Haut.performed += Haut;
        playerinputAction.PlayerMap.Haut.Enable();
        playerinputAction.PlayerMap.Bas.performed += Bas;
        playerinputAction.PlayerMap.Bas.Enable();
        playerinputAction.PlayerMap.Gauche.performed += Gauche;
        playerinputAction.PlayerMap.Gauche.Enable();
        playerinputAction.PlayerMap.Droite.performed += Droite;
        playerinputAction.PlayerMap.Droite.Enable();

        playerinputAction.PlayerMap.Jump.performed += DoJump;
        playerinputAction.PlayerMap.Jump.Enable();

        rb= this.GetComponent<Rigidbody>();
    }
    private void OnDisable(){
        movement.Disable();
        playerinputAction.PlayerMap.Jump.Disable();
    }
    private void DoJump(InputAction.CallbackContext context){
    Debug.Log("Jump");
    rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }
    private void Haut(InputAction.CallbackContext context){
    Debug.Log("déplacement");
    rb.AddForce(0,0,1, ForceMode.Impulse);
    }
     private void Bas(InputAction.CallbackContext context){
    Debug.Log("déplacement");
    rb.AddForce(0,0,-1, ForceMode.Impulse);
    }
     private void Gauche(InputAction.CallbackContext context){
    Debug.Log("déplacement");
    rb.AddForce(-1,0,0, ForceMode.Impulse);
    }
     private void Droite(InputAction.CallbackContext context){
    Debug.Log("déplacement");
    rb.AddForce(1,0,0, ForceMode.Impulse);
    }
    private void Update(){
    if(!IsOwner){
        return;
    }
   // var input = InputPlayer.current;
  /* 
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
 */  
   
    
}
}

