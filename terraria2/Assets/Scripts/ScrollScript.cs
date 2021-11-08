using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public GameObject spikeObj,target;
    public Transform parent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject spawnedObj = Instantiate(spikeObj, target.transform.position, target.transform.rotation);
        spawnedObj.transform.SetParent(parent);
        ScrollScript scriptObj = spawnedObj.GetComponent<ScrollScript>();
        scriptObj.target = target;
        scriptObj.parent = parent;

        Destroy(gameObject);
    }
}
