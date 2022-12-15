using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandSpawnerLogic : MonoBehaviour
{
    public float yPos = 0.0f;
    public float angleModulate = 45f;
    public float posModulate = 0.5f;
    public GameObject prefab;
    public GameObject selectedObject;
    private bool turning = false;
    Vector3 trueMousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {/*
        if (Input.GetButton("SpawnElement"))*/
        Vector3 mousePos = Input.mousePosition;
        Camera cam = Camera.main;
        Ray ray = cam.ScreenPointToRay(mousePos);
        float factor = Mathf.InverseLerp(1.0f, -1.0f , ray.direction.y)*2.0f-1.0f;
        trueMousePos = ray.GetPoint(cam.transform.position.y / factor);
        trueMousePos.y = yPos;
        if (Input.GetKeyDown("1"))
        {
            CreateElement(prefab);
        }
        if(Input.GetMouseButtonDown(0))
        {
            if (selectedObject)
            {
                if (!turning)
                {
                    turning = true;
                }
                else
                {
                    Select(null);
                }
            }
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider && hit.collider.gameObject)
                    {
                        if (hit.collider.gameObject)
                        {
                            Debug.Log(hit.collider.gameObject);
                            Select(hit.collider.gameObject);
                        }
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("deleted");
            Destroy(selectedObject);    
            Select(null);
        }
        if (selectedObject != null)
        {
            Debug.Log("yes");
            if (turning)
            {
                selectedObject.transform.Rotate(roundAngle(Vector3.Angle(trueMousePos - selectedObject.transform.position, selectedObject.transform.forward)));
            }
            else
            {
                
                selectedObject.transform.position = roundPos(trueMousePos);
            }
        }

    }

    Vector3 roundPos(Vector3 value)
    {
        return new Vector3(Mathf.Round(value.x / posModulate) * posModulate, value.y, Mathf.Round(value.z / posModulate) * posModulate);
    }
    Vector3 roundAngle(float value)
    {
        return new Vector3(0f, Mathf.Round(value / angleModulate) * angleModulate, 0f);
    }

    public void CreateElement(GameObject obj = null)
    {
        GameObject newInstance = Instantiate(obj, trueMousePos, Quaternion.identity);
        newInstance.tag = "UserEditable";
        Select(newInstance);
        Debug.Log(selectedObject);
    }

    void Select(GameObject obj = null)
    {
        if(obj == null || obj.tag == "UserEditable")
        {
            Debug.Log("Selected");
            turning = false;
            selectedObject = obj;
        }
    }
}
