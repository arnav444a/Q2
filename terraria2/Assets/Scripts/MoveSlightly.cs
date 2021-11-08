using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlightly : MonoBehaviour
{
    public float speed = 2f;
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * Time.fixedDeltaTime * speed);
    }
}
