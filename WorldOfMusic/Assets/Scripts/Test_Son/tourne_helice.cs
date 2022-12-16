using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tourne_helice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f,50f,0f);
    }
}
