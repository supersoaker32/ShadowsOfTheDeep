using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BatteryListener : MonoBehaviour
{
    public ButtonHandler primaryButtonLeft = null;
    [SerializeField] FlashlightSanity flashlight = null;

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
        flashlight.battery = true;
        flashlight.batteryLevel = 100f;
    }
}
