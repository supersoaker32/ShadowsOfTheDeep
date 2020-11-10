using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BatteryListener : MonoBehaviour
{
    public ButtonHandler primaryButtonLeft = null;
    [SerializeField] FlashlightSanity flashlight = null;
    [SerializeField] Inventory inventory = null;

    private void OnEnable()
    {
        primaryButtonLeft.OnButtonDown += ReloadBattery;
    }

    private void OnDisable()
    {
        primaryButtonLeft.OnButtonDown -= ReloadBattery;
    }

    private void ReloadBattery(XRController controller)
    {
        Debug.Log("Reloaded battery.");
        
        if(inventory.batteries.Count > 0)
        {
            //Make sure all batteries are not active, then set first to be active
            foreach(Battery battery in inventory.batteries)
            {
                if (battery.activeBattery) battery.activeBattery = false;
            }
            flashlight.battery = inventory.batteries.First();
            flashlight.battery.activeBattery = true;
        }
        else
        {
            Debug.Log("No batteries in inventory");
        }

    }
}
