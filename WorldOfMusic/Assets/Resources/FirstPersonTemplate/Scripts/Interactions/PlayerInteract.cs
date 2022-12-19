using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    
    public bool isReaching = false;
    public bool isInteracted = false;
    public GameObject text1;
	public GameObject souris;
    
    //Initialisation du script :
    void Start() {
        text1.SetActive(false);
		souris.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            isReaching = true;
            Reach();
            Debug.Log(other.gameObject);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        isReaching = false;
        text1.SetActive(false);
		souris.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&isReaching)
        {
            Interact();
            Debug.Log("TEST");

        }
    }
    
    
    

    void Reach()
    { 
        Debug.Log("Le joueur est entré dans la zone du collider");
		souris.SetActive(true);
    }
                                          
   void Interact()
   {
       Debug.Log("Le joueur a interagi avec l'objet");
       isInteracted = true;
       if (isInteracted == true)
       {
           	Debug.Log("L'objet a été interagi");
          	//On affiche l'objet Text1
           	text1.SetActive(true);
			//Et on masque l'objet Souris
			souris.SetActive(false);	
       }

   }


}
