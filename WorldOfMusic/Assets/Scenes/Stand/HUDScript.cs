using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    private List<ButGenerator.ObjetStructure> _sourceObjects = new();
    
    public StandSpawnerLogic LogicScript;
    public StandExporterScript StandExporter;
    public void spawnElement(GameObject g)
    {
        Debug.Log(g);
        LogicScript.CreateElement(g.transform.GetChild(3).GetComponent<buttonScript>().prefab);
    }
    public void ExportScene()
    {
        StandExporter.SaveStand();
    }

    public void ImportScene()
    {
        StandExporter.LoadStand();
    }

    public void addObject(ButGenerator.ObjetStructure obj)
    {
        _sourceObjects.Add(obj);
    }

    public GameObject GetPrefabFromName(string name)
    {
        foreach (ButGenerator.ObjetStructure o in _sourceObjects)
        {
            if (name.Contains(o.prefab.name))
            {
                return o.prefab;
            }
        }
        return null;
    }
}
