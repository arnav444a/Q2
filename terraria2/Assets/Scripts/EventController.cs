using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventController : MonoBehaviour
{
    public AudioManager audioManager;
    public Animator MainMenuAni;
    public void Play()
    {
        MainMenuAni.SetTrigger("MainMenuAni");

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOp.allowSceneActivation = false;
        StartCoroutine(MainWait(asyncOp));

        audioManager.Play("Line1");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }

    IEnumerator MainWait(AsyncOperation asyncOp)
    {
        yield return new WaitForSeconds(2.1f);
        asyncOp.allowSceneActivation = true;
    }
    
    public void OnClick()
    {
        audioManager.Play("Click");
    }
    public void onHover()
    {
        audioManager.Play("Hover");
    }

}
