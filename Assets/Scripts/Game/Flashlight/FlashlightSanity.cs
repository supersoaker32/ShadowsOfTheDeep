using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightSanity : MonoBehaviour
{
    [SerializeField] SceneScript script = null;
    [SerializeField] Light light = null;

    public Battery battery = null;

    private bool flashlightOn = false;
    public void EnableFlashlight()
    {
        if(battery != null)
        {
            if (battery.activeBattery && battery.charge > 0)
            {
                Debug.Log("Flashlight on");
                flashlightOn = true;
                light.enabled = true;
            }
            else if(!battery.activeBattery)
            {
                Debug.Log("No batteries");
            }
            else
            {
                Debug.Log($"Dead batteries: {battery.charge}");
            }

        }
    }

    public void DisableFlashlight()
    {
        Debug.Log("Flashlight off");
        flashlightOn = false;
        light.enabled = false;
    }

    private void Update()
    {
        //Dev mode to kill battery
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                battery.charge = -100;
            }
        }

        if (!flashlightOn)
        {
            Debug.Log("Sanity decreased -0.0002: flashlight off");
            script.insanityDisplay.value -= 0.0002f;
        }
        else
        {
            Debug.Log("Sanity increased +0.0001: flashlight on");
            script.insanityDisplay.value += 0.0001f;
        }
        if(battery != null)
        {
            if(battery.charge <= 0 || !battery.activeBattery)
            {
                script.insanityDisplay.value -= 0.0001f;
            }
            else
            {
                battery.charge -= 0.01f;
            }

        }
    }
}
