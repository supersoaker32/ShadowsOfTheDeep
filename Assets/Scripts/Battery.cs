using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] Inventory inventory = null;
    public float charge = 100;
    public bool activeBattery = false;
    public void AddToInventory()
    {
        gameObject.SetActive(false);
        inventory.batteries.Add(this);
    }

    private void Update()
    {
        //Dev mode to kill battery
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                charge = -100;
            }
        }
            //Remove dead batteries from inventory
            if (charge <= 0)
        {
            gameObject.SetActive(false);
            inventory.batteries.Remove(this);
            Debug.Log("Battery dead. Removed from inventory.");
            Destroy(this);
        }
    }
}
