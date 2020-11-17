using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SceneScript : MonoBehaviour
{
    //Environment
    [SerializeField] AudioSource atmosphereSound = null;

    //Power
    [SerializeField] PowerOn powerScript = null;
    [SerializeField] public Slider powerDisplay = null;
    [SerializeField] Volume powerVol = null;
    public bool power = false;
    public float lightLevel = 0;

    //HUD
    public Slider insanityDisplay = null;
    public Slider hungerDisplay = null;
    public Slider thirstDisplay = null;

    void Awake()
    {
        RenderSettings.fog = true;
        RenderSettings.fogDensity = 0.01f;
        atmosphereSound.Play();
        powerDisplay.value = 100.0f;
        insanityDisplay.value = 0;
        hungerDisplay.value = 100;
        thirstDisplay.value = 100;
        powerVol.enabled = true;
        powerVol.weight = 1;
        power = false;
        powerScript.PowerDisabled();

        if (Application.isEditor) Debug.Log("Debug mode is enabled");
    }

    private void Update()
    {
        //Dev mode
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                powerScript.PowerEnabled();

                Debug.Log("Power enabled and full");
                powerDisplay.value = 100f;
                power = true;
            }

            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                powerScript.PowerDisabled();

                Debug.Log("Power disabled and empty");
                powerDisplay.value = 0f;
                power = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Insanity reset to 0");
                insanityDisplay.value = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Debug.Log("Insanity set to max");
                insanityDisplay.value = 100;
            }
        }

        //If power is on, reduce power as time continues
        if (power && powerDisplay.value > 0)
        {
            powerDisplay.enabled = true;
            powerDisplay.value -= 0.01f;
            Debug.Log("Power level drained by .01 from ambient power usage");
            powerVol.weight = 0;
        }
        else
        {
            powerDisplay.enabled = false;
        }

        //Turn off power if no power
        if (powerDisplay.value <= 0)
        {
            power = false;
            powerScript.PowerDisabled();
        }

        if(!power)
        {
            powerDisplay.value += 0.01f;
            Debug.Log("Power level increased by .008 from no power usage");
            powerVol.weight = 1;
        }

        //Increase insanity over time
        insanityDisplay.value += 0.0005f;
        Debug.Log("Insanity increased by .0005 from being alone");

        //Constantly reduce hunger
        hungerDisplay.value -= 0.0015f;
        Debug.Log("Hunger decreased by .0015 from ambience");
        
        //Constantly reduce thirst
        thirstDisplay.value -= 0.003f;
        Debug.Log("Thirst decreased by .003 from ambience");
    }

    public void PowerOnPressed()
    {
        power = !power;
    }
}
