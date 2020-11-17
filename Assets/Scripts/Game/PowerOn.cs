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

    //Room
    [SerializeField] GameObject[] lightningEffects = null;
    [SerializeField] DialInteractable fusebox = null;
    [SerializeField] JumpScares scare = null;
    [SerializeField] GameObject monster = null;
    [SerializeField] AudioSource scareSound = null;


    public bool jumpscare = true;

    public void SwitchOn(int step)
    {
        if (box.m_FusePresent)
        {

            //Disable fusebox
            if (step == 0)
            {
                Debug.Log("Turn off power");
                PowerDisabled();
            }

            //Enable fusebox
            else
            {
                Debug.Log("Turn on power");
                PowerEnabled();
                if (jumpscare)
                {
                    StartCoroutine(scare.MonsterJumpScare(monster, scareSound, 2.5f));
                    jumpscare = false;
                }
            }
        }

        //Turn off fusebox if there's no fuse
        else
        {
            Debug.Log("No fuse present");
            PowerDisabled();
        }
    }

    public void SwitchPartial()
    {
        float angle = fusebox.CurrentAngle;
        if(angle > .9f)
        {
            SwitchOn(1);
        }
    }



    public void PowerEnabled()
    {
        Debug.Log("Power on");
        RenderSettings.fogDensity = 0.005f;

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
