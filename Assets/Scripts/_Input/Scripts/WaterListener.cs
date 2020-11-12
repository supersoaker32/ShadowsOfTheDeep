using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterListener : MonoBehaviour
{
    public ButtonHandler primaryButtonRight = null;
    [SerializeField] Inventory inventory = null;
    [SerializeField] SceneScript scene = null;

    private void OnEnable()
    {
        primaryButtonRight.OnButtonDown += DrinkWater;
    }

    private void OnDisable()
    {
        primaryButtonRight.OnButtonDown -= DrinkWater;
    }

    private void DrinkWater(XRController controller)
    {
        Debug.Log("Water triggered");

        //Get first water, drink water, then remove from inventory
        if (inventory.water.Count > 0)
        {
            Water water = inventory.water.First();
            if (water != null)
            {
                //Add thirstQuench to thirstDisplay
                scene.thirstDisplay.value += water.thirstQuench;

                //Cap fullness at 100
                Debug.Log("Drank first water");
                if (scene.thirstDisplay.value > 100) scene.thirstDisplay.value = 100;
                Debug.Log($"Ate {water.thirstQuench}");
                inventory.water.Remove(water);
            }
        }
        else
        {
            Debug.Log("No water in inventory");
        }

    }
}
