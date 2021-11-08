using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncreaseFast : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<ChangeGravController>().speed += 5f;
            Debug.Log("Speed increased!");
        }
    }
}
