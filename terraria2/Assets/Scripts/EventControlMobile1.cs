using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventControlMobile1 : MonoBehaviour
{
    public Mover1 playerScript;
    float x;
    float t;
    public QtoKill death;
    PauseMenuScript pauseMenu;
    private void Awake()
    {
        pauseMenu =FindObjectOfType<PauseMenuScript>();
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
        death.deathQ = true;
    }
    public void PauseButton()
    {
        pauseMenu.escaped = true;
    }
}
