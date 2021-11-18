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
    }
    IEnumerator Transitioning(int room)
    {
        transition.SetBool("Fade", true);
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + room);


    }
}
