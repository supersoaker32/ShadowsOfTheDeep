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
    [SerializeField] Slider powerDisplay = null;
    public bool power = false;
    public float powerLevel;
    public float lightLevel = 0;

    //HUD
    public Slider insanityDisplay = null;
    public Slider hungerDisplay = null;
    public Slider thirstDisplay = null;

    //Inventory

    void Start()
    {
        RenderSettings.fog = true;
        RenderSettings.fogDensity = 0.01f;
        atmosphereSound.Play();
        powerLevel = 0f;
        insanityDisplay.value = 0;
        hungerDisplay.value = 100;
        if (Application.isEditor)
        {
            Debug.Log("Debug mode is enabled");
            powerScript.devMode = true;
        }
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
                powerLevel = 100f;
                power = true;
            }

            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                powerScript.PowerDisabled();

                Debug.Log("Power disabled and empty");
                powerLevel = 0f;
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

            //Jumpscare only happens when power is initially turned on, adjusting power variable here
            if (powerScript.jumpscare) power = true;

        //If power is on, reduce power as time continues
        if (powerScript.powerOn && powerLevel > 0)
        {
            powerDisplay.enabled = true;
            if (power)
            {
                powerLevel -= 0.01f;
                Debug.Log("Power level drained by .01 from ambient power usage");
            }
            else
            {
                powerLevel += 0.008f;
                Debug.Log("Power level increased by .008 from no power usage");
            }
        }
        else
        {
            powerDisplay.enabled = false;
        }
        powerDisplay.value = powerLevel;

        //Turn off power if no power
        if (powerLevel <= 0)
        {
            power = false;
            powerScript.PowerDisabled();
        }

        //Increase insanity over time
        insanityDisplay.value += 0.0005f;
        Debug.Log("Insanity increased by .0005 from being alone");

        hungerDisplay.value -= 0.0015f;
        Debug.Log("Hunger decreased by .0015 from ambience");

        thirstDisplay.value -= 0.003f;
        Debug.Log("Thirst decreased by .003 from ambience");
    }

    public void PowerOnPressed()
    {
        power = !power;
    }
}
