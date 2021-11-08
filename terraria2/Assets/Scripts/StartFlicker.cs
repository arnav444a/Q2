using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlicker : MonoBehaviour
{
    public GameObject flickerSign;
    public Material mat1, mat2;
    public AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            FlickerScript flickerScript = flickerSign.AddComponent<FlickerScript>();
            flickerScript.mat1 = mat1;
            flickerScript.mat2 = mat2;
            Debug.Log("Added Component");
        }

    }
}
