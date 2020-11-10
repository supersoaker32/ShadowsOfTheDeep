using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class PowerOn : MonoBehaviour
{
    //Box
    [SerializeField] FuseBox box = null;
    [SerializeField] GameObject[] powerFeatures= null;
    [SerializeField] AudioSource power = null;
    public bool powerOn = false;
    public bool devMode = false;

    //Room
    [SerializeField] GameObject[] lightningEffects = null;
    [SerializeField] GameObject monster = null;
    [SerializeField] AudioSource scareSound = null;

    public bool jumpscare = true;

    public void SwitchOn(int step)
    {
        if (box.m_FusePresent)
        {
            if(jumpscare) StartCoroutine(MonsterJumpScare(2.5f));

            //Disable fusebox
            if (step == 0)
            {
                PowerDisabled();
            }

            //Enable fusebox
            else
            {
                PowerEnabled();
            }
        }

        //Turn off fusebox if there's no fuse
        else
        {
            PowerDisabled();
        }
    }

    IEnumerator MonsterJumpScare(float seconds)
    {            
        //Get camera position
        Vector3 screenDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //Spawn monster on left or right randomly
        int choose = UnityEngine.Random.Range(0, 1);
        int z = choose == 0 ? 1 : -1;

        //Set position for monster jump scare
        Vector3 position = screenDimensions + new Vector3(0, 0, z);
        position.y = 0;
        monster.transform.position = position;

        //Activate jumpscare, disable monster after seconds
        monster.SetActive(true);
        scareSound.Play();
        yield return new WaitForSeconds(seconds);
        monster.SetActive(false);
        scareSound.Stop();

        //Activate only on the first trigger
        jumpscare = false;
    }

    public void PowerEnabled()
    {
        RenderSettings.fogDensity = 0.0001f;
        powerOn = true;
        Debug.Log("PowerOn: " + powerOn);

        //Enable power control
        foreach (GameObject powerFeature in powerFeatures)
        {
            powerFeature.SetActive(true);
        }

        //Turn on power sounds
        if (power != null)
        {
            if (power.isPlaying)
            {
                power.Stop();
                power.Play();
            }
            else
            {
                power.Play();

                //Enable lightning effects
                foreach (GameObject lightning in lightningEffects)
                {
                    lightning.SetActive(true);
                }
            }
        }
    }

    public void PowerDisabled()
    {
        RenderSettings.fogDensity = 0.01f;
        powerOn = false;
        Debug.Log("PowerOn: " + powerOn);

        //Disable power control
        foreach (GameObject powerFeature in powerFeatures)
        {
            powerFeature.SetActive(false);
        }

        //Disable power sounds and lightning effects
        if (power.isPlaying) power.Stop();
        foreach (GameObject lightning in lightningEffects)
        {
            lightning.SetActive(false);
        }
    }
}
