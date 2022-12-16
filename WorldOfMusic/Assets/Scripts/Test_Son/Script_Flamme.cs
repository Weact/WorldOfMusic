using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Flamme : MonoBehaviour
{
    public int band;

    public ParticleSystem system;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Sound_Peer.bandBuffer[band] > 6f)
        {
            Debug.Log("test + haut " + Sound_Peer.bandBuffer[band]);
            system.Play();
            transform.localScale = new Vector3(5f, 3.2f, Sound_Peer.bandBuffer[band]);
        }
        
    }
}
