using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dino : MonoBehaviour
{
    public GameObject successText, failText, superSuccessText;
    public Button feedButton;
    public bool velo, caudi, anklyo, tRex, brachy;

    public Animator dinoAnim;
    public VelociraptorBuff veloBuff;
    public CaudiBuff caudiBuff;

    public LifeSystem lifeSystem;
    public GameObject meat, green;
    public bool dropGreen;

    public int damage = 5;
    private static bool tRexBlock = false;

    /*  Feeding Chance
    70   success - loses resources and obtains Trust
    30   fail - loses resources but does not obtain Trust (dinosaur runs away)
    */

    private void Start()
    {
        PlayerPrefs.SetInt("veloTrust", 0);
        PlayerPrefs.SetInt("caudiTrust", 0);
        PlayerPrefs.SetInt("anklyoTrust", 0);
        PlayerPrefs.SetInt("tRexTrust", 0);
        PlayerPrefs.SetInt("brachyTrust", 0);
    }

    private void Update()
    {

        if (velo)
        {
            //unable button while resources not enough
            if (PlayerPrefs.GetInt("Meat") >= 2)
            {
                feedButton.interactable = true;
            }
            else
            {
                feedButton.interactable = false;
            }
        }

        if (caudi)
        {
            if (PlayerPrefs.GetInt("Meat") >= 2 && PlayerPrefs.GetInt("Green") >= 2)
            {
                feedButton.interactable = true;
            }
            else
            {
                feedButton.interactable = false;
            }
        }

        if (anklyo || brachy)
        {
            if (PlayerPrefs.GetInt("Green") >= 5)
            {
                feedButton.interactable = true;
            }
            else
            {
                feedButton.interactable = false;
            }
        }

        if (tRex)
        {
            if (PlayerPrefs.GetInt("Meat") >= 10)
            {
                feedButton.interactable = true;
            }
            else
            {
                feedButton.interactable = false;
            }
        }


    }

    public void FeedDino()
    {

        int randomNumber = Random.Range(0, 100);

        //success - loses resources and obtains Trust
        if (randomNumber <= 70)
        {
            dinoAnim.SetTrigger("Success");

            Debug.Log("Success feeding!");
            
            if (velo)
            {
                if (PlayerPrefs.GetInt("Meat") >= 2)
                {
                    PlayerPrefs.SetInt("veloTrust", PlayerPrefs.GetInt("veloTrust", 0) + 1);
                    PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - 2);

                    Debug.Log("Successfully Feeding Velociraptor");

                    if (PlayerPrefs.GetInt("veloTrust", 0) >= 3)
                    {
                        veloBuff.veloBuffOn = true;
                        Debug.Log("Successfully Gained Trust from Velociraptor");
                        Debug.Log("Velociraptor BUFF ON");
                    }

                    Debug.Log("Velo Trust Meter:" + PlayerPrefs.GetInt("veloTrust", 0));
                }

            }
            if (caudi)
            {
                if (PlayerPrefs.GetInt("Meat") >= 2 && PlayerPrefs.GetInt("Green") >= 2)
                {
                    PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - 2);
                    PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") - 2);

                    Debug.Log("Successfully Feeding Caudipteryx");
                    PlayerPrefs.SetInt("caudiTrust", PlayerPrefs.GetInt("caudiTrust", 0) + 1);
                    Debug.Log("Caudi Trust Meter:" + PlayerPrefs.GetInt("caudiTrust", 0));


                    if (PlayerPrefs.GetInt("caudiTrust", 0) >= 3)
                    {
                        caudiBuff.caudiBuffOn = true;
                        Debug.Log("Successfully Gained Trust from Caudipteryx");
                        Debug.Log("Caudipteryx BUFF ON");
                    }
                }

            }
            if (brachy)
            {
                if (PlayerPrefs.GetInt("Green") >= 5)
                {
                    successText.SetActive(true);
                    PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") - 5);

                    Debug.Log("Successfully Feeding Brachiosaurus");
                    PlayerPrefs.SetInt("brachyTrust", PlayerPrefs.GetInt("brachyTrust") + 1);
                    Debug.Log("brachy Trust Meter:" + PlayerPrefs.GetInt("brachyTrust", 0));

                    if (PlayerPrefs.GetInt("brachyTrust") >= 3)
                    {
                        if (lifeSystem.lifePts >= 80)
                        {
                            lifeSystem.lifePts = 100;
                            Debug.Log("Successfully Gained Trust from Brachiosaurus ");
                            Debug.Log("HP + 20. HP for now is" + lifeSystem.lifePts);
                        }

                        else
                        {
                            lifeSystem.lifePts = lifeSystem.lifePts + 20;
                            Debug.Log("Successfully Gained Trust from Brachiosaurus ");
                            Debug.Log("HP + 20. HP for now is" + lifeSystem.lifePts);
                        }
                    }
                    
                }
            }
            if(anklyo)
            {
                if (PlayerPrefs.GetInt("Green") >= 5)
                {
                    successText.SetActive(true);
                    PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") - 5);

                    Debug.Log("Successfully Feeding Ankylosaurus");
                    PlayerPrefs.SetInt("anklyoTrust", PlayerPrefs.GetInt("anklyoTrust") + 1);
                    Debug.Log("Ankylo Trust Meter:" + PlayerPrefs.GetInt("anklyoTrust", 0));


                    if (PlayerPrefs.GetInt("anklyoTrust") >= 3)
                    {
                        PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") + 2);
                    }

                }

            }
            if (tRex)
            {
                if (PlayerPrefs.GetInt("Meat") >= 10)
                {
                    successText.SetActive(true);
                    PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - 10);

                    PlayerPrefs.SetInt("tRexTrust", PlayerPrefs.GetInt("tRexTrust", 0) + 1);
                    Debug.Log("T-Rex Trust Meter:" + PlayerPrefs.GetInt("tRexTrust", 0));


                    if (PlayerPrefs.GetInt("tRexTrust", 0) >= 3)
                    {
                        tRexBlock = true;
                        Debug.Log("Successfully Gained Trust from T-Rex");
                    }

                }
            }

            successText.SetActive(true);
            Destroy(gameObject);

        }
        else   //loses resources but does not obtain Trust (dinosaur runs away)
        {

            dinoAnim.SetTrigger("Fail");

            if (velo)
            {
                if (PlayerPrefs.GetInt("Meat") >= 2)
                {
                    PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - 2);
                }

            }
            if (caudi)
            {
                if (PlayerPrefs.GetInt("Meat") >= 2 && PlayerPrefs.GetInt("Green") >= 2)
                {
                    PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - 2);
                    PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") - 2);
                }


            }
            if (anklyo || brachy)
            {
                if (PlayerPrefs.GetInt("Green") >= 5)
                {
                    PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") - 5);

                }

            }
            if (tRex)
            {
                if (PlayerPrefs.GetInt("Meat") >= 10)
                {
                    PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - 10);
                }

                

            }
            failText.SetActive(true);
            Destroy(gameObject);
        }
    }



    /*  Killing Chance
        60   success - get resourse, lost hp
        30   fail - no resourse, if carnivore lost hp, else run away
        10   super success - get resourse without losing hp (T- Rex effect skip)
    */


    public void KillDino()
    {

        int randomNumber = Random.Range(0, 100);

        //success - get resourse, lost hp
        if (randomNumber <= 60)
        {
            dinoAnim.SetTrigger("Death");

            
            Debug.Log("Success Chance!");
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
            //Debug.Log("Dino Population: " + PlayerPrefs.GetInt("Dino"));

            successText.SetActive(true);
            Instantiate(meat, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        else
        {
            randomNumber -= 60;
            
            //fail - no resourse, if carnivore lost hp, else run away
            if (randomNumber <= 30)
            {
                //escape animation


                if(tRex)
                {
                    if (tRexBlock)
                    {
                        Debug.Log("Luckily your T-Rex block it and save you. Zero damage.");
                        tRexBlock = false;

                    }
                    else
                    {
                        Debug.Log("Damage taken from T-Rex: " + damage);
                        lifeSystem.lifePts -= damage;
                    }
                }
                else
                {
                    Debug.Log("Unfortunatly! The dinosaur run away!");
                }

                failText.SetActive(true);

                Destroy(gameObject);
            }
            else
            {
                randomNumber -= 30;
                dinoAnim.SetTrigger("Death");

                //super success - get resourse without losing hp (T- Rex effect skip)
                if (randomNumber <= 10)
                {
                    Debug.Log("Super Success Chance!");
                    superSuccessText.SetActive(true);

                    if (dropGreen)
                    {
                        Instantiate(green, transform.position, Quaternion.identity);
                    }

                    PlayerPrefs.SetInt("Dino", PlayerPrefs.GetInt("Dino") - 1);
                    //Debug.Log("Dino Population: " + PlayerPrefs.GetInt("Dino"));

                    Instantiate(meat, transform.position, Quaternion.identity);
                    Destroy(gameObject);

                }
            }
        }

    }

}
