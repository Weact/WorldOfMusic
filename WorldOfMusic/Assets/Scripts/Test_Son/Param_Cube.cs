using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Param_Cube : MonoBehaviour
{
    public int band;
    public bool lampe;
    public float startScale, scaleMultiplier;
    void Update()
    {
        
        if (lampe == true)
        {
            transform.localRotation = Quaternion.Euler(Sound_Peer.bandBuffer[band] * scaleMultiplier * startScale,0f,0f);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0f,Sound_Peer.bandBuffer[band] * scaleMultiplier * startScale,0f);
        }
    }
}
