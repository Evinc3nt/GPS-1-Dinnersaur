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
        StartCoroutine(Transitioning());
        
        
    }

    public void Setting()
    {
        StartCoroutine(Transitioning());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        
    }

    IEnumerator Transitioning()
    {
        transition.SetBool("Fade", true);
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
