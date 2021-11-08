using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomOut : MonoBehaviour
{
    public CinemachineVirtualCamera cvcam;
    private float t=0f,startVal;
    public float assignedVal = 12f;
    private bool lerpVal,notWork;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 && cvcam.m_Lens.OrthographicSize != 10f)
        {
            if (t < 1)
            {
                lerpVal = true;
                startVal = cvcam.m_Lens.OrthographicSize;
                Debug.Log(startVal);
            }
        }
    }

    IEnumerator LerpValues()
    {
        yield return null;
        cvcam.m_Lens.OrthographicSize = Mathf.Lerp(startVal, assignedVal, t);
        t += 0.5f * Time.deltaTime;
    }

    private void Update()
    {
        if (lerpVal)
        {
            StartCoroutine(LerpValues());
        }
    }
}
