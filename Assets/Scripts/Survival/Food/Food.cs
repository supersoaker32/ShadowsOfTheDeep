using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] Inventory inventory = null;
    [SerializeField] public float hungerFill = 10.0f;

    private void Awake()
    {
        
    }

    public void AddToInventory()
    {
        gameObject.SetActive(false);
        inventory.food.Add(this);
    }
}
