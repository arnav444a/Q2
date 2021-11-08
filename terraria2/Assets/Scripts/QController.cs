using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QController : MonoBehaviour
{
    pressQ qObj;
    public GameObject pressQObj;
    public GameObject enableText,button;
    public BoxCollider2D boxColliderDialogue;
    public bool qInCollider;
 

    public void PressQ()
    {
        qObj = FindObjectOfType<pressQ>();

        if (qObj)
        {
            enableText.SetActive(true);
            button.SetActive(true);

            qObj.Qpress = true;
            Debug.Log("Turned Qpress on");
        }
        else
        {
            
            if (qInCollider)
            {
                pressQObj.SetActive(true);

            }
        }
    }
}
