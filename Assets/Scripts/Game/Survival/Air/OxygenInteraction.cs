using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class OxygenInteraction : MonoBehaviour
{
    [SerializeField] OxygenConverter oxygen = null;
    [SerializeField] Slider playerOxygen = null;
    [SerializeField] Volume vol = null;
    private Slider oxygenBar = null;

    private float oxygenDecrease = 0.001f;
    private float breathDecrease = 0.001f;

    private void Awake()
    {
        playerOxygen.value = 100f;
        oxygenBar = oxygen.oxygenBar;
    }

    private void Update()
    {
        //Reduce oxygen in base constantly
        oxygen.oxygenBar.value -= oxygenDecrease;
        Debug.Log($"Oxygen decreased by {oxygenDecrease}");

        if (oxygenBar.value <= 20)
        {
            //Player can't breathe below 20% oxygen levels
            playerOxygen.value -= breathDecrease;
            Debug.Log($"Oxygen levels below 20% breath loss imminent: {breathDecrease}");

            //Player rapidly loses oxygen at 10% oxygen levels
            if (oxygenBar.value <= 10)
            {
                playerOxygen.value -= breathDecrease;
                Debug.Log($"Oxygen levels below 10% breath loss imminent: {breathDecrease}");
            }

            //Player drastically loses oxygen at 5% oxygen levels
            if (oxygenBar.value <= 5)
            {
                playerOxygen.value -= breathDecrease * 3;
                Debug.Log($"Oxygen levels below 5% breath loss imminent: {breathDecrease * 3}");
            }

            //Almost guarenteed death at 0% oxygen levels
            if (oxygenBar.value <= 0)
            {
                playerOxygen.value -= breathDecrease * 5;
                Debug.Log($"Oxygen levels critical breath loss imminent: {breathDecrease * 5}");
            }
        }

        if (playerOxygen.value <= 50f)
        {
            vol.enabled = true;
            vol.weight = 100 - playerOxygen.value;
        }
    }

}
