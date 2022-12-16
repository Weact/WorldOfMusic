using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandActivationZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (IsArtiste()) 
        {
            StandSingleton.Instance.OpenEditorScene();
            
        }
    }
    private bool IsArtiste() // TODO
    {
        return true;
    }
}
