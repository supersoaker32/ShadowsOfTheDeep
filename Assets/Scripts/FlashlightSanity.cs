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
                Debug.Log("Dead batteries");
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
        if (!flashlightOn)
        {
            Debug.Log("Sanity decreased: flashlight off");
            script.insanityDisplay.value -= 0.0002f;
        }
        if(battery != null)
        {
            if (battery.activeBattery && battery.charge > 0)
            {
                battery.charge -= 0.2f;
            }
            if(battery.charge <= 0 || !battery)
            {
                script.insanityDisplay.value -= 0.0001f;
            }

        }
    }
}
