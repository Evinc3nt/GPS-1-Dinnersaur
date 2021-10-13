using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvesting : MonoBehaviour
{
    public Animator animator;

    public Transform hitBox;
    public float hitRange = 0.5f;
    public LayerMask plantLayer;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Harvest");
        Collider2D[] hitPlants = Physics2D.OverlapCircleAll(hitBox.position, hitRange, plantLayer);

        foreach (Collider2D plant in hitPlants)
        {
            Debug.Log("Harvested " + plant.name);
            plant.GetComponent<Plant>().KillSelf();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (hitBox == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(hitBox.position, hitRange);

    }
}
