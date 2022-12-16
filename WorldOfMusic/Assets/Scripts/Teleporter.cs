using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    [SerializeField] // This gameobject is assigned in the Inspector. Also, Teleporter is a Prefab that contains a gameObject called TargetLocation
    // This is the gameobject you need to move to setup the teleporter.
    // Unpack this prefab completely when including in a scene, then manipulate the gameobjects
    private GameObject targetLocation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = targetLocation.transform.position;
        }
    }
}
