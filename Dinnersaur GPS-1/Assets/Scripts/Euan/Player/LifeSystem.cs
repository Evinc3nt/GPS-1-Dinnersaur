using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int lifePts = 100;
    public Text lifePoints;
    public Animator animator;
    public Animator scene;
    private PlayerMovement move;
    public Slider hpSlider;

    void Start()
    {
        //lifePoints = GetComponent<Text>();
        move = FindObjectOfType<PlayerMovement>();
        hpSlider.maxValue = lifePts;
        hpSlider.value = lifePts;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = lifePts;
        lifePoints.text = lifePts.ToString();

        if (lifePts <= 0)
        {
            dead();
        }
    }

    public void dead()
    {        
         lifePts = 0;
         move.moveSpeed = 0;
         StartCoroutine(deadScene());
        
    }
    private IEnumerator deadScene()
    {
        animator.SetBool("isDead", true);
        yield return new WaitForSecondsRealtime(1f);
        scene.SetBool("isDead", true);
    }

}
