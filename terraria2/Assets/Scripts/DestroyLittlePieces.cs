using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLittlePieces : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerShatter")
        {
            Destroy(collision.gameObject);
        }
    }
}
