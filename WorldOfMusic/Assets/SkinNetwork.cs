using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Collections;

public class SkinNetwork : NetworkBehaviour
{
    [SerializeField] private GameObject skin;
    public GameObject skin1;


    public List<GameObject> skinss = new List<GameObject>();
    private void Awake(){
        skin = GetComponent<GameObject>();
    }
     public override void OnNetworkSpawn()
    {
    if (IsOwner)
    {
        skin = skinss[FindObjectOfType<NetworkManagerUI>().color];
        Instantiate(skin, transform.position,transform.rotation, transform.GetChild(0) );
    }
    }
}
