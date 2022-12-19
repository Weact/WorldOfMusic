using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class StandSpawnerLogic : MonoBehaviour
{
    public string userObjectName;
    public float yPos = 0.0f;
    public float angleModulate = 45f;
    public float posModulate = 0.5f;
    public GameObject userObjects;
    GameObject selectedObject;
    private bool _turning = false;
    Vector3 _trueMousePos;
    private Camera _cam;

    // Update is called once per frame
    private void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {/*
        if (Input.GetButton("SpawnElement"))*/
        Vector3 mousePos = Input.mousePosition;
        Ray ray = _cam.ScreenPointToRay(mousePos);
        float factor = Mathf.InverseLerp(1.0f, -1.0f , ray.direction.y)*2.0f-1.0f;
        _trueMousePos = ray.GetPoint(_cam.transform.position.y / factor);
        _trueMousePos.y = yPos;
        if(Input.GetMouseButtonDown(0))
        {
            if (selectedObject)
            {
                if (!_turning)
                {
                    _turning = true;
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
            Debug.Log("deleted object" + selectedObject);
            Destroy(selectedObject);    
            Select(null);
        }
        if (selectedObject != null)
        {
            if (_turning)
            {
                selectedObject.transform.Rotate(RoundAngle(Vector3.Angle(_trueMousePos - selectedObject.transform.position, selectedObject.transform.forward)));
            }
            else
            {
                
                selectedObject.transform.position = RoundPos(_trueMousePos);
            }
        }

    }

    Vector3 RoundPos(Vector3 value)
    {
        return new Vector3(Mathf.Round(value.x / posModulate) * posModulate, value.y, Mathf.Round(value.z / posModulate) * posModulate);
    }
    Vector3 RoundAngle(float value)
    {
        return new Vector3(0f, Mathf.Round(value / angleModulate) * angleModulate, 0f);
    }

    public void CreateElement(GameObject obj = null, Vector3 pos = default, Quaternion rot = default, bool select = true)
    {
        GameObject newInstance;
        if (userObjects == null)
        {
            userObjects = GameObject.Find(userObjectName);
        }
        if(userObjects != null)
        {
            newInstance = Instantiate(obj, pos, rot, userObjects.transform);
        }
        else
        {
            Debug.LogError("UserObjects undefined, won't be able to export");
            newInstance = Instantiate(obj, pos, rot);
        }
        newInstance.tag = "UserEditable";
        if(select){Select(newInstance);}
        Debug.Log(selectedObject);
    }


    void Select(GameObject obj = null)
    {
        if(obj == null || obj.tag == "UserEditable")
        {
            Debug.Log("Selected object" + obj);
            _turning = false;
            selectedObject = obj;
        }
    }
}
