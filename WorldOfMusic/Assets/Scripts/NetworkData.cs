using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkData : NetworkBehaviour
{
    void NCalcul_OnValueChanged(int ancien, int nouveau)
    {
        Debug.Log("Prout");
    }
    
    public NetworkVariable<int> nCalcul;
    // Start is called before the first frame update
    void Start()
    {
        nCalcul = new NetworkVariable<int>(0);
        nCalcul.OnValueChanged += NCalcul_OnValueChanged;
    }
    
    public void Incremente()
    {
        nCalcul.Value += 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(nCalcul.Value); //GameObject.FindObjectsOfType<NetworkPlayerLocal>().Length);
    }
}
