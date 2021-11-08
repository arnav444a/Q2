using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLines : MonoBehaviour
{
    AudioManager audioManager;
    public string clipName;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioManager.Play("Line2");
        Destroy(gameObject);
    }
}
