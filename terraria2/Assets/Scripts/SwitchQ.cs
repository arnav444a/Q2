using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchQ : MonoBehaviour
{
    public GameObject QKillButton, QTalkButton;
    public IEnumerator WaitForSwitch(Image clicker)
    {
        yield return new WaitForSeconds(0.2f);
        clicker.raycastTarget= true;
        Debug.Log("Enabled");

    }
    public void Switch(Image button)
    {
        StartCoroutine(WaitForSwitch(button));
    }
}
