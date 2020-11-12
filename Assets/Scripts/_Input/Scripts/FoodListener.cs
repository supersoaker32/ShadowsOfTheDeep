using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodListener : MonoBehaviour
{
    public ButtonHandler secondaryButtonLeft = null;
    [SerializeField] Inventory inventory = null;
    [SerializeField] SceneScript scene = null;


    private void OnEnable()
    {
        secondaryButtonLeft.OnButtonDown += EatFood;
    }

    private void OnDisable()
    {
        secondaryButtonLeft.OnButtonDown -= EatFood;
    }

    private void EatFood(XRController controller)
    {
        Debug.Log("Ate first food");

        //Get first food, eat food, then remove from inventory
        if (inventory.food.Count > 0)
        {
            Food food = inventory.food.First();
            if (food != null)
            {
                //Add food to hungerDisplay
                scene.hungerDisplay.value += food.hungerFill;

                //Cap fullness at 100
                if (scene.hungerDisplay.value > 100) scene.hungerDisplay.value = 100;
                Debug.Log($"Ate {food.hungerFill}");
                inventory.food.Remove(food);
            }
        }
        else
        {
            Debug.Log("No food in inventory");
        }
    }
}
