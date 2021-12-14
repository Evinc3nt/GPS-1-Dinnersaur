using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public Animator cutscene;
    public int nextSceneIndex;

    void Start()
    {
        StartCoroutine(WaitAnim());
    }


    IEnumerator WaitAnim()
    {
        Debug.Log("Start cutscene");
        yield return new WaitForSeconds(cutscene.GetCurrentAnimatorStateInfo(0).length + cutscene.GetCurrentAnimatorStateInfo(0).normalizedTime);

        Debug.Log("Done cutscene");

        SceneManager.LoadScene(nextSceneIndex);

    }
}
