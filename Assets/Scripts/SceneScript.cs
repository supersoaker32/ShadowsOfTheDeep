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
    [SerializeField] Volume volume = null;
    [SerializeField] Slider powerDisplay = null;
    [SerializeField] GameObject[] powerFeatures = null;

    //HUD
    public Slider insanityDisplay = null;

    public bool power = false;
    public float powerLevel;
    public float lightLevel = 0;

    void Start()
    {
        atmosphereSound.Play();
        powerLevel = 0f;
        insanityDisplay.value = 0;
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
                Debug.Log("Power enabled and full");
                powerLevel = 100f;
                powerScript.powerOn = true;
                power = true;

                //Enable power control
                foreach (GameObject powerFeature in powerFeatures)
                {
                    powerFeature.SetActive(true);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Insanity reset to 0");
                insanityDisplay.value = 0;
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
                volume.enabled = false;
                powerLevel -= 0.01f;
            }
            else
            {
                volume.enabled = true;
                powerLevel += 0.008f;
            }
        }
        else
        {
            powerDisplay.enabled = false;
            volume.enabled = true;
        }
        powerDisplay.value = powerLevel;

        //Turn off power if no power
        if (powerLevel <= 0)
        {
            power = false;
            foreach(GameObject powerFeature in powerFeatures)
            {
                powerFeature.SetActive(false);
            }
        }

        //Increase insanity over time
        insanityDisplay.value += 0.0005f;
    }

    public void PowerOnPressed()
    {
        power = !power;

    }
}
