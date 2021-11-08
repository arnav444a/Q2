using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGrav : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.gravityScale = 0.25f;
            playerRigidbody.mass = 5f;
            playerRigidbody.drag = 5f;

            Debug.Log("Ran gravityScale script");
        }
    }
}
