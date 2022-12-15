using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSkin : MonoBehaviour
{
    public List<GameObject> skins;
    public CanvasGroup menu;
	public bool Affiched = false;
	public bool ToucheL = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //On affiche le menu au début du programme
        AfficheMenu();
    }
    
        void AfficheMenu()
        {
			Debug.Log("Touche M pressée - Menu affiché");
            menu.alpha = 1;
            menu.interactable = true;
            menu.blocksRaycasts = true;
			Affiched = true;
			ToucheL = false;
			//On bloque les touches de déplacement du joueur
			
        }
   
	     void CacheMenu()
    	{       
            Debug.Log("Touche M pressée - Menu caché");
            menu.alpha = 0;
            menu.interactable = false;
            menu.blocksRaycasts = false;
        	Affiched = false;
			ToucheL = false;
    	}
	
    
    // Update is called once per frame
    void Update()
    {
		//Si les conditions sont remplies, on affiche le menu
		if (Affiched == false && Input.GetKeyDown(KeyCode.M) && ToucheL == true)
        {
			//On appelle la fonction AfficheMenu
            AfficheMenu();
        }
		//Si les conditions sont remplies, on cache le menu
		if (Affiched == true && Input.GetKeyDown(KeyCode.M) && ToucheL == true)
    	{
        	//On appelle la fonction CacheMenu
	    	CacheMenu();
    	}
		
		if (Input.GetKeyUp(KeyCode.M) && ToucheL == false)
		{
	        ToucheL = true;
		}
    }

    

}
