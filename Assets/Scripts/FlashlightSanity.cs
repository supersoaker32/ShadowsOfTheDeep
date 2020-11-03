using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSanity : MonoBehaviour
{
    [SerializeField] SceneScript script = null;

    private bool flashlightOn = false;
    public void EnableFlashlightSanity()
    {
        Debug.Log("Flashlight on");
        flashlightOn = true;
    }

    public void DisableFlashlightSanity()
    {
        Debug.Log("Flashlight off");
        flashlightOn = false;
    }

    private void Update()
    {
        if (!flashlightOn)
        {
            Debug.Log("Sanity decreased: flashlight off");
            script.insanityDisplay.value -= 0.0002f;
        }
    }
}
