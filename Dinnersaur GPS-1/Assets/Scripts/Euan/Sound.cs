using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static AudioClip alertSound, anklyoSound, brachySound, caudiSound, clickSound, dinoeatgreensSound, dinoeatmeatSound, failnoiseSound,
        harvestSound, killdinoSound, mcconsumeSound, morningnoiseSound, resourceobtainSound,
        supersuccessnoiseSound, trexSound, trexstompSound, trustupSound, walkSound;

    static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        alertSound = Resources.Load<AudioClip>("alert");
        anklyoSound = Resources.Load<AudioClip>("anklyo");
        brachySound = Resources.Load<AudioClip>("brachy");
        caudiSound = Resources.Load<AudioClip>("caudi");
        clickSound = Resources.Load<AudioClip>("click");
        dinoeatgreensSound = Resources.Load<AudioClip>("dinoeatgreens");
        dinoeatmeatSound = Resources.Load<AudioClip>("dinoeatmeat");
        failnoiseSound = Resources.Load<AudioClip>("failnoise");
        harvestSound = Resources.Load<AudioClip>("harvest");
        killdinoSound = Resources.Load<AudioClip>("killdino");
        mcconsumeSound = Resources.Load<AudioClip>("mcconsume");
        morningnoiseSound = Resources.Load<AudioClip>("morningnoise");
        resourceobtainSound = Resources.Load<AudioClip>("resourceobtain");
        supersuccessnoiseSound = Resources.Load<AudioClip>("supersuccessnoise");
        trexSound = Resources.Load<AudioClip>("trex");
        trexstompSound = Resources.Load<AudioClip>("trexstomp");
        trustupSound = Resources.Load<AudioClip>("trustup");
        walkSound = Resources.Load<AudioClip>("walk");
    }

    public static void play_sound(string clip)
    {
        switch (clip)
        {
            case "alert":
                audioSource.PlayOneShot(alertSound);
                break;

            case "anklyo":
                audioSource.PlayOneShot(anklyoSound);
                break;

            case "brachy":
                audioSource.PlayOneShot(brachySound);
                break;

            case "caudi":
                audioSource.PlayOneShot(caudiSound);
                break;

            case "click":
                audioSource.PlayOneShot(clickSound);
                break;

            case "dinoeatgreens":
                audioSource.PlayOneShot(dinoeatgreensSound);
                break;

            case "dinoeatmeat":
                audioSource.PlayOneShot(dinoeatmeatSound);
                break;

            case "failnoise":
                audioSource.PlayOneShot(failnoiseSound);
                break;

            case "harvest":
                audioSource.PlayOneShot(harvestSound);
                break;

            case "killdino":
                audioSource.PlayOneShot(killdinoSound);
                break;

            case "mcconsume":
                audioSource.PlayOneShot(mcconsumeSound);
                break;

            case "morningnoise":
                audioSource.PlayOneShot(morningnoiseSound);
                break;

            case "resourceobtain":
                audioSource.PlayOneShot(resourceobtainSound);
                break;

            case "supersuccessnoise":
                audioSource.PlayOneShot(supersuccessnoiseSound);
                break;

            case "trex":
                audioSource.PlayOneShot(trexSound);
                break;

            case "trexstomp":
                audioSource.PlayOneShot(trexstompSound);
                break;

            case "trustup":
                audioSource.PlayOneShot(trustupSound);
                break;

            case "walk":
                audioSource.PlayOneShot(walkSound);
                break;
        }
    }
}
