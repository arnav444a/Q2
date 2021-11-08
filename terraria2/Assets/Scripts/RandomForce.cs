using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForce : MonoBehaviour
{
    public Rigidbody2D rb;
    [HideInInspector]
    public Vector2 playerRbVel;

    public Rigidbody2D playerObj;
    public float explosionForce = 20f;
    private void Start()
    {
        rb.velocity = playerRbVel;
        rb.AddForce(new Vector2(Random.Range(100f,-100), Random.Range(100f, -100)) * explosionForce);
    }
}
