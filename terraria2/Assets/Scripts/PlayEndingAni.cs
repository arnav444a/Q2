using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayEndingAni : MonoBehaviour
{
    public Animator ani;
    public GameObject AniObj;
    public GameObject disableObj;
    AsyncOperation loadScene;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {

            StartCoroutine(PlayAniWait());
            StartCoroutine(EndEndngSequence());
            StartCoroutine(ChangeLevel());
        }
    }

    IEnumerator PlayAniWait()
    {
        Debug.Log("working");
        yield return new WaitForSeconds(4f);
        AniObj.SetActive(true);
        disableObj.SetActive(false); 
        Debug.Log("Wait working");
        ani.SetTrigger("EndingAni");

        loadScene = SceneManager.LoadSceneAsync(0);
        loadScene.allowSceneActivation = false;
    }
    IEnumerator EndEndngSequence()
    {
        yield return new WaitForSeconds(17f);
        Debug.Log("Playing Animation !");
        ani.SetTrigger("EndingAniText");


    }

    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(20f);

        loadScene.allowSceneActivation = true;

    }
}
