using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recording : MonoBehaviour
{
    public GameObject playerObj;
    List<Vector2> recordingPositions = new List<Vector2>();

    private void FixedUpdate()
    {
        recordingPositions.Add(playerObj.transform.position);
    }
}
