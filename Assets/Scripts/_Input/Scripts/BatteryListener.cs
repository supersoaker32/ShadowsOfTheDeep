using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BatteryListener : MonoBehaviour
{
    public ButtonHandler primaryButton = null;

    private void OnEnable()
    {
        primaryButton.OnButtonDown += ReloadBattery;
    }

    private void OnDisable()
    {
        primaryButton.OnButtonDown -= ReloadBattery;
    }

    private void ReloadBattery(XRController controller)
    {
        Debug.Log("Batteries reloaded.");
    }
}
