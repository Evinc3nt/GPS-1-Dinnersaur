using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dino : MonoBehaviour
{
    public Button feedButton;

    [Header("Dino Type")]
    public bool velo;
    public bool caudi;
    public bool anklyo;
    public bool tRex;
    public bool brachy;

    [Space]
    public Animator playerAnim;

    public VelociraptorBuff veloBuff;
    public CaudiBuff caudiBuff;

    public LifeSystem lifeSystem;
    public TrustMeter trustMeter;
    public GameObject meat, green;
    public bool dropGreen;

    public int damage = 5;
    private static bool tRexBlock;
    public static bool success, fail, superSuccess, dinoKilled, dinoFailKill;

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

        success = fail = superSuccess = dinoKilled = false;
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
        if (anklyo)
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

        if (brachy)
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
            success = true;
            playerAnim.SetTrigger("SuccessTame");

            Debug.Log("Success feeding!");
            
            if (velo)
            {

                if (PlayerPrefs.GetInt("Meat") >= 2)
                {
                    PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - 2);
                    Debug.Log("Successfully Feeding Velociraptor");

                    if (PlayerPrefs.GetInt("veloTrust", 0) >= 3)
                    {
                        veloBuff.veloBuffOn = true;
                        Debug.Log("Successfully Gained Trust from Velociraptor");
                        Debug.Log("Velociraptor BUFF ON");
                    }
                    else
                    {
                        PlayerPrefs.SetInt("veloTrust", PlayerPrefs.GetInt("veloTrust", 0) + 1);
                    }

                    Debug.Log("Velo Trust Meter:" + PlayerPrefs.GetInt("veloTrust", 0));
                    trustMeter.SetTrustMeter(PlayerPrefs.GetInt("veloTrust", 0));
                }

            }
            if (caudi)
            {

                if (PlayerPrefs.GetInt("Meat") >= 2 && PlayerPrefs.GetInt("Green") >= 2)
                {
                    PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - 2);
                    PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") - 2);

                    Debug.Log("Successfully Feeding Caudipteryx");



                    if (PlayerPrefs.GetInt("caudiTrust", 0) >= 3)
                    {
                        caudiBuff.caudiBuffOn = true;
                        Debug.Log("Successfully Gained Trust from Caudipteryx");
                        Debug.Log("Caudipteryx BUFF ON");
                    }
                    else
                    {
                        PlayerPrefs.SetInt("caudiTrust", PlayerPrefs.GetInt("caudiTrust", 0) + 1);
                    }
                    Debug.Log("Caudi Trust Meter:" + PlayerPrefs.GetInt("caudiTrust", 0));
                    trustMeter.SetTrustMeter(PlayerPrefs.GetInt("caudiTrust",0));
                }

            }
            if (brachy)
            {

                if (PlayerPrefs.GetInt("Green") >= 5)
                {
                    PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") - 5);

                    Debug.Log("Successfully Feeding Brachiosaurus");


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
                    else
                    {
                        PlayerPrefs.SetInt("brachyTrust", PlayerPrefs.GetInt("brachyTrust") + 1);

                    }

                    trustMeter.SetTrustMeter(PlayerPrefs.GetInt("brachyTrust", 0));
                    Debug.Log("brachy Trust Meter:" + PlayerPrefs.GetInt("brachyTrust", 0));
                }
            }
            if(anklyo)
            {

                if (PlayerPrefs.GetInt("Green") >= 5)
                {

                    PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") - 5);

                    Debug.Log("Successfully Feeding Ankylosaurus");

                    if (PlayerPrefs.GetInt("anklyoTrust") >= 3)
                    {
                        PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") + 2);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("anklyoTrust", PlayerPrefs.GetInt("anklyoTrust") + 1);
                    }

                    Debug.Log("Ankylo Trust Meter:" + PlayerPrefs.GetInt("anklyoTrust", 0));
                    trustMeter.SetTrustMeter(PlayerPrefs.GetInt("anklyoTrust",0));

                }

            }
            if (tRex)
            {

                if (PlayerPrefs.GetInt("Meat") >= 10)
                {               
                    PlayerPrefs.SetInt("Meat", PlayerPrefs.GetInt("Meat") - 10);

                    Debug.Log("Successfully Feeding T-Rex");

                    if (PlayerPrefs.GetInt("tRexTrust", 0) >= 3)
                    {
                        tRexBlock = true;
                        Debug.Log("Successfully Gained Trust from T-Rex");
                    }
                    else
                    {
                        PlayerPrefs.SetInt("tRexTrust", PlayerPrefs.GetInt("tRexTrust", 0) + 1);
                    }

                    Debug.Log("T-Rex Trust Meter:" + PlayerPrefs.GetInt("tRexTrust", 0));
                    trustMeter.SetTrustMeter(PlayerPrefs.GetInt("tRexTrust",0));

                }
            }
        }
        else   //loses resources but does not obtain Trust (dinosaur runs away)
        {

            fail = true;

            playerAnim.SetTrigger("FailTame");

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

            

        }
        Destroy(gameObject);
    }



    /*  Killing Chance
        60   success - get resource, lost hp
        30   fail - no resource, lost hp
        10   super success - get resourse without losing hp (T- Rex effect skip)
    */


    public void KillDino()
    {

        int randomNumber = Random.Range(0, 100);

        //success - get resourse, lost hp
        if (randomNumber <= 60)
        {
            dinoKilled = true;

            playerAnim.SetTrigger("SuccessKill");

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
            Debug.Log("Dino Population: " + PlayerPrefs.GetInt("Dino"));

            Instantiate(meat, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        else
        {
            randomNumber -= 60;

            playerAnim.SetTrigger("FailKill");

            //fail - no resourse, lost hp
            if (randomNumber <= 30)
            {
                dinoFailKill = true;

                if (tRexBlock)
                {
                    Debug.Log("Luckily your T-Rex block it and save you. Zero damage.");
                    tRexBlock = false;

                }
                else
                {
                    lifeSystem.lifePts -= damage;
                }

                Destroy(gameObject);

            }
            else
            {
                randomNumber -= 30;

                //super success - get resourse without losing hp (T- Rex effect skip)
                if (randomNumber <= 10)
                {

                    playerAnim.SetTrigger("SuccessKill");


                    Debug.Log("Super Success Chance!");
                    superSuccess = true;

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
        }


    }

}
