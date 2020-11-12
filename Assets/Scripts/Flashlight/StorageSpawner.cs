using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageSpawner : MonoBehaviour
{
    [SerializeField] GameObject battery = null;
    [SerializeField] GameObject food = null;
    [SerializeField] GameObject water = null;
    [SerializeField] Inventory inventory = null;
    void Start()
    {
        //Initialize each spawned object's inventory to the one in scene
        battery.GetComponent<Battery>().inventory = inventory;
        food.GetComponent<Food>().inventory = inventory;
        water.GetComponent<Water>().inventory = inventory;

        //10% chance each location will have a battery
        float spawn = Random.Range(0.0f, 1f);
        if (spawn <= 0.1f)
        {
            Debug.Log("Spawned battery");
            GameObject batteryClone = Instantiate(battery, transform.position, Random.rotation);
            batteryClone.SetActive(true);
        }

        //10% chance each location will have food if it's not a battery
        else if (spawn > .1f && spawn <= .2f)
        {
            Debug.Log("Spawn food");
            GameObject foodClone = Instantiate(food, transform.position, Random.rotation);
            foodClone.SetActive(true);
        }

        //10% chance each location will have water if it's not food or a battery
        else if(spawn > .2f && spawn <= .3f)
        {
            Debug.Log("Spawn water");
            GameObject waterClone = Instantiate(water, transform.position, Random.rotation);
            waterClone.SetActive(true);
        }
    }
}
