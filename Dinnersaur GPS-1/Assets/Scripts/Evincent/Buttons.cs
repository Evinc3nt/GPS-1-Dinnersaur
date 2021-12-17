using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public Animator transition;
    public float transTime = 1f;

    private void Start()
    {
        transition.SetBool("Fade", false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        Time.timeScale = 1;
        StartCoroutine(Transitioning(1));
        

    }

    public void MainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);

    }


    public void Setting()
    {
        Time.timeScale = 1;
        StartCoroutine(Transitioning(2));
        
    }
    
    public void Back()
    {
        Time.timeScale = 1;
        StartCoroutine(Transitioning(-1));
    }


    public void Retry()
    {
        Time.timeScale = 1;
        StartCoroutine(Transitioning(0));
        FindObjectOfType<EndingManager>().SetDay();

        SceneManager.LoadScene(2);
    }

    IEnumerator Transitioning(int room)
    {
        transition.SetBool("Fade", true);
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + room);


    }

    public void FirstLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }

    public void LoadDinoEnd()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(11);
    }
    public void LoadHumanEnd()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(12);
    }
    public void LoadBalancedEnd()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(13);
    }

}
