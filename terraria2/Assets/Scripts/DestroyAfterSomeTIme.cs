using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSomeTIme : MonoBehaviour
{
    float timeStart, timeEnd;

    private void Awake()
    {
        timeStart = Time.time;
        Debug.Log(timeStart);

    }
    private void Update()
    {
        timeEnd = Time.time;
        if(timeEnd-timeStart>5f)
        {
            Destroy(gameObject);
        }
    }
}
