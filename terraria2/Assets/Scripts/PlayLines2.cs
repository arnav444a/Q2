using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLines2 : MonoBehaviour
{
    AudioManager audioManager;
    public string clipName;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioManager.Play("Line6");
        Destroy(gameObject);
    }
}
