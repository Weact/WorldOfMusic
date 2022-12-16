using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class TextEmptyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (StandSingleton.Instance)
        {
            GetComponent<Text>().text = StandSingleton.Instance.standJson;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
