using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QtoInteract : MonoBehaviour
{
    public GameObject QInteract;
    public Animator textBoxAni;
    public PlayScript playScript;
    public QController qController;

    public GameObject QKillButton, QTextButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            QInteract.SetActive(true);

            if (QKillButton != null)
            {
                QKillButton.SetActive(false);
                QTextButton.SetActive(true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (QKillButton != null)
        {
            QKillButton.SetActive(true);
            QTextButton.SetActive(false);
        }
        qController.qInCollider = false;
        playScript = FindObjectOfType<PlayScript>();
        if (playScript == null)
        {
            textBoxAni.SetTrigger("endTalking");
        StartCoroutine(waitTurnFalse());

        }
        else if(playScript != null)
        {
            if (playScript.loadAniEnd == false)
            {
                playScript.loadAniEnd = true;
                Debug.Log("loadAni is false");
            }
            else
            {

                playScript.loadAniEnd = true;
                textBoxAni.SetTrigger("endTalking");
                StartCoroutine(waitTurnFalse());
            }
        }
        else
        {
            playScript.loadAniEnd = true;
            textBoxAni.SetTrigger("endTalking");
            StartCoroutine(waitTurnFalse());

        }
    }

    private IEnumerator waitTurnFalse()
    {
        yield return new WaitForSeconds(0.3f);
        QInteract.SetActive(false);
    }
}
