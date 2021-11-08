using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu,controlUI;
    public bool isPaused,escaped;
    public Animator pauseMenuAni;
    public AudioManager audioManager;
    private void Update()
    {
        if (escaped && !isPaused)
        {
            escaped = false;
            Pause();
            isPaused = true;
            Debug.Log("Paused");
        }
        else if(escaped && isPaused)
        {
            Resume();
            isPaused = false;
           
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        controlUI.SetActive(false);
    }
    public void Resume()
    {
        controlUI.SetActive(true);
        pauseMenuAni.SetTrigger("ResumeAniTrigger");
        Time.timeScale = 1f;
        isPaused = false;

        //controlUI.SetActive(true);
        StartCoroutine(resumeWait());
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Go to MainMenu");
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
    IEnumerator resumeWait()
    {
        yield return new WaitForSeconds(0.183f);
        pauseMenu.SetActive(false) ;

        escaped = false;
        
    }
    public void OnClick()
    {
        audioManager.Play("Click");
    }
    public void onHover()
    {
        audioManager.Play("Hover");
    }
    bool AnimatorIsPlaying(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
}
