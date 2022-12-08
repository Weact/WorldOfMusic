using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Param_Cube : MonoBehaviour
{
    public int band;

    public Quaternion rotation;
    public float rotaX;
    public bool lampe;

    public float speed=.5f;
    /*[SerializeField]
    private GameObject bracket;
    [SerializeField]
    private GameObject body;*/
    public float startScale, scaleMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lampe == true)
        {
            
           // Debug.Log(Test_Son.freqBand[band] * scaleMultiplier * startScale); 
            rotation = Quaternion.Euler(Mathf.Lerp(transform.position.x,Test_Son.freqBand[band] * scaleMultiplier * startScale,0.5f) * Mathf.Lerp(transform.position.x,Test_Son.freqBand[band] * scaleMultiplier * startScale,0.5f) ,transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            Debug.Log("rotation x "+ rotation.x);
            transform.rotation = rotation;
        }
        else
        {   
          // Debug.Log(Test_Son.freqBand[band] * scaleMultiplier * startScale); 
            rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Mathf.Lerp(transform.position.y,Test_Son.freqBand[band] * scaleMultiplier * startScale,0.5f) * Mathf.Lerp(transform.position.y,Test_Son.freqBand[band] * scaleMultiplier * startScale,0.5f) , transform.rotation.eulerAngles.z);
            Debug.Log("rotation y" + rotation.y);
            transform.rotation = rotation;
        }

    }
}
