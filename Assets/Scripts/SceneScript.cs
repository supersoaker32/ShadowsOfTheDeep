using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SceneScript : MonoBehaviour
{
    [SerializeField] AudioSource atmosphereSound = null;
    [SerializeField] PowerOn powerScript = null;
    [SerializeField] Volume volume = null;
    [SerializeField] Slider powerDisplay = null;
    [SerializeField] GameObject[] powerFeatures = null;

    public bool power = false;
    public float powerLevel = 100f;
    float difficultyTimer = 0;
    void Start()
    {
        atmosphereSound.Play();
        powerLevel = 100f;
    }

    private void Update()
    {
        //Jumpscare only happens when power is initially turned on, adjusting power variable here
        if (powerScript.jumpscare) power = true;

        //If power is on, reduce power as time continues
        if (powerScript.powerOn && powerLevel > 0)
        {
            difficultyTimer += 0.01f;
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

        //Add difficulty
        //if (difficultyTimer >= 100) powerScript.powerOn = false;

        if (powerLevel <= 0)
        {
            power = false;
            foreach(GameObject powerFeature in powerFeatures)
            {
                powerFeature.SetActive(false);
            }
        }
    }

    public void PowerOnPressed()
    {
        power = !power;

    }
}
