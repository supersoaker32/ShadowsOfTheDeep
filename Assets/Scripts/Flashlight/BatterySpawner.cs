using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySpawner : MonoBehaviour
{
    [SerializeField] GameObject battery = null;
    void Start()
    {
        //40% chance each location will have a battery
        if (Random.Range(0.0f, 1f) > 0.4f)
        {
            Debug.Log($"Spawned battery at {transform}");
            GameObject batteryClone = Instantiate(battery, transform.position, Random.rotation);
            batteryClone.SetActive(true);
        }
    }
}
