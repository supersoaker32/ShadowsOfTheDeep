using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPurification : MonoBehaviour
{
    [SerializeField] Slider[] progressBars = null;
    [SerializeField] GameObject water = null;
    [SerializeField] Transform[] waterSpawn = null;

    [SerializeField] SceneScript scene = null;

    private float powerConsumption = .0001f;

    private bool power = false;
    void Update()
    {
        //Dev mode
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                progressBars[0].value = 1;
                progressBars[1].value = 1;
                progressBars[2].value = 1;
            }
        }


        if (gameObject.activeSelf) power = true;

        if (power)
        {
            progressBars[0].value += 0.0001f;
            progressBars[1].value += 0.0001f;
            progressBars[2].value += 0.0001f;

            scene.powerDisplay.value -= powerConsumption;
            Debug.Log($"Water draining power by {powerConsumption}");
        }

        for (int i = 0; i < progressBars.Length; i++)
        {
            //When progressbars fill, spawn food at a location with random rotation
            if (progressBars[i].value >= 1)
            {
                int randomSpawn = Random.Range(0, waterSpawn.Length - 1);
                GameObject waterClone = Instantiate(water, waterSpawn[randomSpawn].transform.position, Random.rotation);
                waterClone.SetActive(true);
                Debug.Log($"Water spawned at spawn: {randomSpawn} with position {waterSpawn[randomSpawn].transform.position}");
                progressBars[i].value = 0;
            }
        }
    }

    //Method to turn on/off power when button pressed
    public void PowerSwitch()
    {
        power = !power;
    }
}
