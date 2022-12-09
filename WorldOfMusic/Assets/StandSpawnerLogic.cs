using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandSpawnerLogic : MonoBehaviour
{
    public GameObject prefab;
    private GameObject selectedObject;
    private bool turning = false;
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
        /*Vector3 naiveInstancePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        float dist = Mathf.Max(naiveInstancePos.y, 0) - Mathf.Min(0, naiveInstancePos.y);
        Vector3 instancePos = Vector3.LerpUnclamped(cam.transform.position, naiveInstancePos, 1/dist);*/
        Vector3 trueMousePos = ray.GetPoint(cam.transform.position.y/factor);
        if (Input.GetKeyDown("1"))
        {
            Select(Instantiate(prefab, trueMousePos, transform.rotation));
        }
        if(Input.GetKeyDown("mouse 0"))
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
                    if (hit.collider)
                    {
                        /*Select(hit.collider.attachedRigidbody);*/
                    }
                }
            }
        }
        if(Input.GetKeyDown("mouse 1"))
        {
            Destroy(selectedObject);    
            Select(null);
        }
        if (selectedObject)
        {
            if (turning)
            {
                selectedObject.transform.LookAt(trueMousePos);
            }
            else
            {
                selectedObject.transform.position = trueMousePos;
            }
        }

    }

    void Select(GameObject obj = null)
    {
        turning = false;
        selectedObject = obj;
    }
}
