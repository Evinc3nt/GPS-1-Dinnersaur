using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //public bool ListOn = false;

    //List<int> list = new List<int>();

    //private void Start()
    //{
    //    if(ListOn)
    //    {
    //        for (int i = 3; i <= 10; i++)
    //        {
    //            list.Add(i);
    //        }
    //    }

    //}

    public void LoadVariationScene()
    {

        Time.timeScale = 1;

        //int index = Random.Range(0, list.Count - 1);
        //int i = list[index];

        int index = Random.Range(3, 13);
        SceneManager.LoadScene(index);

        //list.RemoveAt(index);
    }



}
