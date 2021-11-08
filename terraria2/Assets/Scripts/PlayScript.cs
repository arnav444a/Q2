using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayScript : MonoBehaviour
{
    public Image button;
    public bool buttonEnabled;
    public string[] lines;
    public  TextMeshPro text;
    int i;
    public GameObject[] disableObjs;
    public GameObject[] enableObjs;
    public Animator cinemaAni,TextBoxAni;
    public GameObject cinemaCanvasObj;
    public GameObject TextBoxObj;

    public QController qController;

    public bool loadAniEnd= true;
    public DeathAdController deaths;

    public GameObject QKillButton, QTextButton;
    public SwitchQ swticher;
    private IEnumerator LineWait()
    {
        string[] hiInLanguages = { "Howdy :D", "Konichiwa box-San", "Heya ;D", "Salut mon ami :D", "Wassup Homie ( ͡❛ ͜ʖ ͡❛)", "Namaste :D", "ni-hao :D", "( ͡ಠ ͜ʖ ͡ಠ)", "Hello :D" };
        List<string> hiList = new List<string>(hiInLanguages);


        text.text = " ";
        if(lines[i]=="...!!")
        {
            deaths = FindObjectOfType<DeathAdController>();
            lines[i] = ". . . Look youve already died a total of " + deaths.totalDeaths + " times . . .";
        }
        if (hiList.Contains(lines[i]))
        {
            
            lines[i] = hiList[Random.Range(0, 9)];
        }
        foreach (char letter in lines[i])
        {
            text.text += letter;
            
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void StartNewLine()
    {
        StopAllCoroutines();
        //StopCoroutine(LineWait());
        i++;
        if (i < lines.Length)
        {
            text.text = "";
            StartCoroutine(LineWait());
            Debug.Log("Started new Line!");
        }
        else
        {
            foreach (GameObject disableObj in disableObjs)
            {
                disableObj.SetActive(false);
            }
            Debug.Log("Started Ending Sequence");
            EndBox();
        }

    }

    public void EndBox()
    {
        if (buttonEnabled)
        {
            button.raycastTarget = false;
            Debug.Log("Enabled Button");
        }
        qController.qInCollider = true;
        text.text = "";
        loadAniEnd = false;
        i = -1;
        cinemaAni.SetTrigger("cinemaOutAni");
        TextBoxAni.SetTrigger("endTalking");
       
        foreach (GameObject enableObj in enableObjs)
        {
            enableObj.SetActive(true);
        }
        if (QKillButton != null)
        {
            
        }
        StartCoroutine(WaitCinemaDisable());
    }

    IEnumerator WaitCinemaDisable()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(waitTurnFalse());

        cinemaCanvasObj.SetActive(false);
    }
    private void Start()
    {
        loadAniEnd = true;
        StartCoroutine(LineWait());
    }
    private IEnumerator waitTurnFalse()
    {
        yield return new WaitForSeconds(0.3f);
        if (buttonEnabled)
        {
            swticher.Switch(button);

        }
        TextBoxObj.SetActive(false);

    }

}
