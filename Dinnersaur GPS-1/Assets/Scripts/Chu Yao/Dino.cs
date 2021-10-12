using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public bool veloBuff, caudiBuff, anklyoBuff, tRexBuff;

    public VelociraptorBuff velo;
    public CaudiBuff caudi;

    public LifeSystem lifeSystem;
    public GameObject meat, green;
    public bool dropGreen;

    public int damage = 5;
    private static bool tRexBlock = false;

    public void tameDino()
    {
        if (veloBuff)
        {
            velo.veloBuffOn = true;
            Debug.Log("Successfully Taming Velociraptor");
            veloBuff = false;
        }
        if (caudiBuff)
        {
            caudi.caudiBuffOn = true;
            Debug.Log("Successfully Taming Caudipteryx");
            caudiBuff = false;
        }
        if (anklyoBuff)
        {
            lifeSystem.lifePts += 20;
            Debug.Log("Successfully Taming Ankylosaurus");
            Debug.Log("HP + 20. HP for now is" + lifeSystem.lifePts);
            anklyoBuff = false;
        }
        if (tRexBuff)
        {
            tRexBlock = true;
            Debug.Log("Successfully Taming T-Rex");
            tRexBuff = false;
        }

        Destroy(gameObject);

    }


    public void killDino()
    {
        if (tRexBlock)
        {
            Debug.Log("Luckily your T-Rex block it and save you. Zero damage.");
            Destroy(gameObject);
            tRexBlock = false;

        }
        else
        {
            Debug.Log("Damage taken: " + damage);
            lifeSystem.lifePts -= damage;
        }

        if (dropGreen)
        {
            Instantiate(green, transform.position, Quaternion.identity);
        }

        Instantiate(meat, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
