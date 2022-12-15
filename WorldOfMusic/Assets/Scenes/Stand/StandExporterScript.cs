using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class StandExporterScript : MonoBehaviour
{
    [SerializeField]HUDScript HUD;
    [SerializeField]StandSpawnerLogic StandLogic;
    [SerializeField]string userObjectsName = "UserObjects";
    [SerializeField]string saveFileName = "stand.json";
    // The structure we want to save and load
    struct SavedObject
    {
        public string name;
        public Vector3 position;
        public Quaternion rotation;
    }

    // Save the objects from the children of the specified game object to a file
    void SaveObjects(GameObject parent, string fileName)
    {
        // Create an array to store the saved objects
        SavedObject[] objects = new SavedObject[parent.transform.childCount];

        // Loop through the children of the game object
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            // Get the current child game object
            GameObject child = parent.transform.GetChild(i).gameObject;
            Debug.Log(parent);
            Debug.Log(child);

            // Create a new SavedObject instance for the child
            objects[i] = new SavedObject
            {
                name = child.name,
                position = child.transform.position,
                rotation = child.transform.rotation
            };
        }
        
        // Convert the array of saved objects to a JSON string
        string json = JsonConvert.SerializeObject(objects, Formatting.Indented, new JsonSerializerSettings()
        { 
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        // Write the JSON string to the file
        File.WriteAllText(fileName, json);
    }
    // Load objects from the specified file and add them as children of the specified game object
    SavedObject[] LoadObjects(string fileName)
    {
        // Read the JSON string from the file
        string json = File.ReadAllText(fileName);

        // Convert the JSON string to an array of SavedObject instances
        SavedObject[] objects = JsonConvert.DeserializeObject<SavedObject[]>(json);

        return objects;
    }  
    
    public void SaveStand()
    {
        GameObject userObjects = GameObject.Find(userObjectsName);
        SaveObjects(userObjects, saveFileName);
        Debug.Log("Saved stand in " + saveFileName);
        //SEND TO SERVER TODO
        
    }

    public void LoadStandEditor()
    {
        //TODO
    }
    public void LoadStand()
    {
        if (!StandLogic)
        {
            Debug.LogError("Need to connect a StandSpawnerLogic to load a stand");
            return;
        }
        SavedObject[] objects = LoadObjects(saveFileName);
        Debug.Log("Loaded stand in " + saveFileName);
        GameObject userObjects = GameObject.Find(userObjectsName);
        for (int i = 0; i < userObjects.transform.childCount; i++)
        {
            Destroy(userObjects.transform.GetChild(i).gameObject);
        }
        
        // Loop through the saved objects
        foreach (SavedObject obj in objects)
        {
            // Create a new game object for the saved object
            GameObject prefab = HUD.GetPrefabFromName(obj.name);
            StandLogic.CreateElement(prefab, obj.position, obj.rotation, false);

        }
    }
}
