using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerScript1 : MonoBehaviour
{
    [HideInInspector]
    public SpriteRenderer spriteR;

    float switcher,randMax=1f;
    public float totalFlickers, minFlickersToChangeSpeed = 2f;
    //public float totalFlickers;
    public Material mat1,mat2;
    AudioManager audioManager;
    private void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
        audioManager = FindObjectOfType<AudioManager>();

    }
    private void Start()
    {
        Debug.Log(spriteR.material);
        StartCoroutine(FlickerLight());
    }
    IEnumerator FlickerLight()
    {
        while (totalFlickers>0)
        {
            yield return new WaitForSeconds(Random.Range(0f, randMax));
            switcher++;
            switch (switcher%2)
            {
                case 0: spriteR.material = mat1;totalFlickers--; audioManager.Play("LightFlicker"); break;
                case 1: spriteR.material = mat2;break;
            }
            if (totalFlickers < minFlickersToChangeSpeed)
            {
                randMax = 0.2f;
            }
        }
        if(totalFlickers == 0)
        {
            totalFlickers = 5f;
            randMax = 1f;

            StartCoroutine(FlickerLight());
        }
    }
}
