using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    public bool gravityUp = false;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            if (gravityUp)
            {
                switch (Physics2D.gravity == new Vector2(0, -9.81f))
                {
                    case true: Physics2D.gravity = new Vector2(0, 9.81f); audioManager.Play("GravityChange"); break;
                    case false: break;
                }
            }
            else
            {
                switch (Physics2D.gravity == new Vector2(0,9.81f))
                {
                    case true: Physics2D.gravity = new Vector2(0, -9.81f);audioManager.Play("GravityChange");break;
                    case false: break;
                }
            }
        }
    }
}
