using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    public StandSpawnerLogic LogicScript;
    public void spawnElement(GameObject g)
    {
        Debug.Log(g);
        LogicScript.CreateElement(g.transform.GetChild(3).GetComponent<buttonScript>().prefab);
    }
}
