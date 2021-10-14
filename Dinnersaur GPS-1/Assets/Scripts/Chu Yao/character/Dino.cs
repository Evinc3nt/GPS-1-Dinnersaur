using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public bool veloBuff, caudiBuff, anklyoBuff, tRexBuff;

    public VelociraptorBuff velo;
    public CaudiBuff caudi;

    public LifeSystem lifeSystem;
    public GameObject meat, green, warningText;
    public bool dropGreen;

    public int damage = 5;
    private static bool tRexBlock = false;

    public void tameDino()
    {
        if (veloBuff)
        {
            if(PlayerPrefs.GetInt("Meat") >= 2)
            {
                PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - 2);

                velo.veloBuffOn = true;
                Debug.Log("Successfully Taming Velociraptor");
                veloBuff = false;

                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Insufficient Resources");
                warningText.SetActive(true);
                killDino();
            }

        }
        if (caudiBuff)
        {
            if(PlayerPrefs.GetInt("Meat") >=2 && PlayerPrefs.GetInt("Green") >=2)
            {
                PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - 2);
                PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") - 2);

                caudi.caudiBuffOn = true;
                Debug.Log("Successfully Taming Caudipteryx");
                caudiBuff = false;

                Destroy(gameObject);

            }
            else
            {
                Debug.Log("Insufficient Resources");
                warningText.SetActive(true);
                killDino();
            }

        }
        if (anklyoBuff)
        {
            if(PlayerPrefs.GetInt("Green") >= 5)
            {
                PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") - 5);
                if (lifeSystem.lifePts >= 80)
                {
                    lifeSystem.lifePts = 100;
                    Debug.Log("Successfully Taming Ankylosaurus");
                    Debug.Log("HP + 20. HP for now is" + lifeSystem.lifePts);
                }

                else
                {
                    lifeSystem.lifePts = lifeSystem.lifePts + 20;
                    Debug.Log("Successfully Taming Ankylosaurus");
                    Debug.Log("HP + 20. HP for now is" + lifeSystem.lifePts);
                }

                anklyoBuff = false;
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Insufficient Resources");
                warningText.SetActive(true);
                killDino();
            }

        }
        if (tRexBuff)
        {
            if(PlayerPrefs.GetInt("Meat") >= 10)
            {
                PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - 10);

                tRexBlock = true;
                Debug.Log("Successfully Taming T-Rex");
                tRexBuff = false;

                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Insufficient Resources");
                warningText.SetActive(true);
                killDino();
            }

        }
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

        PlayerPrefs.SetInt("Dino", PlayerPrefs.GetInt("Dino") - 1);
        Debug.Log("Dino Population: " + PlayerPrefs.GetInt("Dino"));

        Instantiate(meat, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
