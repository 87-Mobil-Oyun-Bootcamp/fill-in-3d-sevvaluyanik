using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private bool isHit = true;

    public GameObject blockSpawner;

    private void Awake()
    {
        blockSpawner = GameObject.FindGameObjectWithTag("BlockSpawner");
   
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obje = other.gameObject;
        if(other.CompareTag("HitBlock") && isHit)
        {
            
            isHit = false;
            Debug.Log(obje);
            Color color = blockSpawner.GetComponent<BlockSpawner>().blockList[obje.transform];
            Debug.Log(color);
            obje.GetComponent<Renderer>().material.color = color;
            obje.tag = "Untagged";
            Destroy(this.gameObject);
        }
    }
}
