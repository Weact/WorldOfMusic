using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptBoutons : MonoBehaviour
{
    public int User = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void Exit()
    {
        Application.Quit();
        Debug.Log("L'application est fermée");
    }

    public void Artist()
    {
        User = 1;
        Debug.Log("Artiste");
    }
    
    public void Fan()
    {
        User = 2;
        Debug.Log("Fan");
    }
    
    public void Connect()
    {
        if(User != 0)
        {
            Debug.Log("Ptdr t co");
            //CacheMenu();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
