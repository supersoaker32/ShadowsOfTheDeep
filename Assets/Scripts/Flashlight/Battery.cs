using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] public Inventory inventory = null;
    public float charge = 100;
    public bool activeBattery = false;

    public void AddToInventory()
    {
        gameObject.SetActive(false);
        inventory.batteries.Add(this);
    }

    private void Update()
    {
        //Remove dead batteries from inventory
        if (charge <= 0)
        {
            gameObject.SetActive(false);
            inventory.batteries.Remove(this);
            Debug.Log("Battery dead. Removed from inventory.");
            Destroy(this);
        }

        if (activeBattery && charge > 0)
        {
            charge -= 0.2f;
        }
    }
}
