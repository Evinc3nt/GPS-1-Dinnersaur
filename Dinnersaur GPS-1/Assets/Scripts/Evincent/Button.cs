using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public Animator transition;
    public float transTime = 1f;
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        StartCoroutine(Transitioning());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
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
        transition.SetBool("Fade", false);
        //SceneManager.LoadScene(Scene);
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//public class Button : MonoBehaviour
//{
//    public void Play()
//    {
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//    }

//    public void Setting()
//    {
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
//    }

//    public void Quit()
//    {
//        Application.Quit();
//    }
//}