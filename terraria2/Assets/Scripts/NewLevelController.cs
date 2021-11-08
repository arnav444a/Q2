using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NewLevelController : MonoBehaviour
{
    public GameObject canvasObj ,portalMask,playerObj;
    public Animator canvasAni, childAni;
    public bool antiGravLevel;
    public CinemachineVirtualCamera cvcam;
    

    private void Awake()
    {
        Time.timeScale = 0f;
        canvasObj.SetActive(true);
        portalMask.SetActive(false);

        canvasAni.SetTrigger("fadeoutAni");
        childAni.SetTrigger("endingTrig");

    }
    private void Update()
    {

        if (!AnimatorIsPlaying(canvasAni))
        {
            Debug.Log("Animation Completed");

            canvasObj.SetActive(false);
            portalMask.SetActive(true);
            playerObj.SetActive(true);
            Time.timeScale = 1f;
            if (antiGravLevel)
            {
                cvcam.m_Lens.OrthographicSize = 7.5f;
            }
            gameObject.SetActive(false);

        }
    }
    bool AnimatorIsPlaying(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
}
