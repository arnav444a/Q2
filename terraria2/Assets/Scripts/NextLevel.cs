using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class NextLevel : MonoBehaviour
{
    public GameObject canvasObj,playerObj,target;
    public SpriteRenderer backgroundPortal;
    public Animator canvasAni,controlsAni;
    AudioManager audioManager;
    public CinemachineVirtualCamera vrcam;

    public bool line2, line4, line6;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            collision.gameObject.SetActive(false);
            controlsAni.SetTrigger("ControlEnding");
            LoadAni();
        }
    }

    public void LoadAni()
    {

        StartCoroutine(Waiter());
    }
    public IEnumerator Waiter()
    {
        yield return null;

        Time.timeScale = 0f;
        //aniPlayerObj.SetTrigger("changeIntensity");
        vrcam.Follow = target.transform;

        canvasObj.SetActive(true);
        playerObj.SetActive(false);
        canvasAni.SetTrigger("fadeInAni");

        //aniObj.SetTrigger("changeIntensity");

        AsyncOperation sceneLoader = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        sceneLoader.allowSceneActivation = false;
        Time.timeScale = 1f;
        if (line2)
        {
            audioManager.Play("Line2");
        }
        else if (line4)
        {
            audioManager.Play("Line4");
        }
        else if (line6)
        {
            audioManager.Play("Line6");
        }
        yield return new WaitForSeconds(2f);

        sceneLoader.allowSceneActivation = true;

        //StartCoroutine(WaitSceneLoad(sceneLoader));
    }
    public IEnumerator WaitSceneLoad(AsyncOperation sceneLoader)
    {
        yield return null;
    }
}
