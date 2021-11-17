using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int lifePts = 100;
    Text lifePoints;
    public Animator animator;
    public Animator scene;
    private PlayerMovement move;
    void Start()
    {
        lifePoints = GetComponent<Text>();
        move = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
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
        yield return new WaitForSeconds(1f);
        scene.SetBool("isDead", true);
    }

    //TODO: 
    /*if (lifePoints <= 0)
     * {
     * GAMEOVER
     * }
     */
}
