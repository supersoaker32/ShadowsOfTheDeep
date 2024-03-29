﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodGrowth : MonoBehaviour
{
    [SerializeField] Slider[] progressBars = null;
    [SerializeField] GameObject[] food = null;
    [SerializeField] Transform[] foodSpawn = null;

    [SerializeField] SceneScript scene = null;

    private bool power = false;
    void Update()
    {
        //Dev mode
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.F))
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
            progressBars[1].value += 0.00009f;
            progressBars[2].value += 0.00008f;

            scene.powerDisplay.value -= 0.0001f;
            Debug.Log("Food draining power by .0001");
        }

        for(int i = 0; i < progressBars.Length; i++)
        {
            //When progressbars fill, spawn food at a location with random rotation
            if (progressBars[i].value >= 1)
            {
                int randomSpawn = Random.Range(0, foodSpawn.Length - 1);
                GameObject foodClone = Instantiate(food[i], foodSpawn[randomSpawn].transform.position, Random.rotation);
                foodClone.SetActive(true);
                Debug.Log($"Food spawned at spawn: {randomSpawn} with position {foodSpawn[randomSpawn].transform.position}");
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
