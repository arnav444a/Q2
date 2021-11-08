using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventControlMobile2 : MonoBehaviour
{
    public Mover2 playerScript;
    float x;
    float t;
    public QtoKill death;
    PauseMenuScript pauseMenu;
    public ChangeGravController changeGrav;

    private void Awake()
    {
        pauseMenu = FindObjectOfType<PauseMenuScript>();
    }
    public void Jump()
    {
        playerScript.jump = true;
        playerScript.timeJumpStart = Time.time;
    }
    public void DashZ()
    {
        playerScript.dash = true;
    }
    public void QKill()
    {
        changeGrav.qPress = true;
    }

    public void PauseButton()
    {
        pauseMenu.escaped = true;
    }
}
