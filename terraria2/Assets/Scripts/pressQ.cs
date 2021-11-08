using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressQ : MonoBehaviour
{
    public bool Qpress;

    public GameObject[] ObjToDisable;
    public GameObject aniObj;
    public Animator ani;

    private void Update()
    {
        if (Qpress)
        {
            Qpress = false;
            aniObj.SetActive(true);
            foreach (GameObject obj in ObjToDisable)
            {
                obj.SetActive(false);

            }
        }
    }
}
