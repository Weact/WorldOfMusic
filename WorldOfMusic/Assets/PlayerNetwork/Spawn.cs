using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameObject.Find("Spawn").transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
