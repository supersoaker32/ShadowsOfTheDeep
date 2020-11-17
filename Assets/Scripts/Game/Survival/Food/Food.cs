using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] public Inventory inventory = null;
    [SerializeField] public float hungerFill = 10.0f;

    public void AddToInventory()
    {
        gameObject.SetActive(false);
        inventory.food.Add(this);
    }
}
