using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandSpawnerLogic : MonoBehaviour
{
    public GameObject prefab;
    private GameObject selectedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {/*
        if (Input.GetButton("SpawnElement"))*/
        Vector3 mousePos = Input.mousePosition;
        if (Input.GetKeyDown("1"))
        {
            selectedObject = Instantiate(prefab, new Vector3(mousePos.x, 100, mousePos.y)*100, transform.rotation);
            Debug.Log(mousePos);
        }

    }
}
