using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class OxygenConverter : MonoBehaviour
{
    [SerializeField] public Slider oxygenBar = null;
    [SerializeField] SceneScript scene = null;

    private bool power = false;

    private void Start()
    {
        oxygenBar.value = 100f;
    }

    private void Update()
    {
        //Dev mode
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                oxygenBar.value = 100f;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                oxygenBar.value = 0f;
            }
        }

        if (gameObject.activeSelf) power = true;

        if (power)
        {
            //Increase by enough to counter constant drain and gain more
            oxygenBar.value += 0.0011f;
            scene.powerDisplay.value -= 0.0001f;
            Debug.Log("Air converter draining power by .0001");
        }
    }

    //Method to turn on/off power when button pressed
    public void PowerSwitch()
    {
        power = !power;
    }
}
