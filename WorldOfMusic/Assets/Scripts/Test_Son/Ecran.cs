using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ecran : MonoBehaviour
{
    public int i = 0;
    public List<Material> materiaux = new List<Material>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("coroutine");
    }

    public IEnumerator coroutine()
    {
        if (i > 1)
        {
            i = 0;
        }
        
        gameObject.GetComponent<Renderer>().material = materiaux[i];

        i++;
        yield return new WaitForSecondsRealtime(10);
        StartCoroutine("coroutine");
    }

}
