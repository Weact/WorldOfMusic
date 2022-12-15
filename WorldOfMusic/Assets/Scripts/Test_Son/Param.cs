using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Param : MonoBehaviour
{
    //private Sound_Peer sound;
    public int band;

    public float startScale, scaleMultiplier;

    public bool useBuffer;

    void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (Sound_Peer.bandBuffer[band] * scaleMultiplier) * startScale, transform.localScale.z);
        }
        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (Sound_Peer.freqBand[band] * scaleMultiplier) * startScale, transform.localScale.z);
        }
    }
}
