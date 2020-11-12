using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] public Inventory inventory = null;
    [SerializeField] public float thirstQuench = 10.0f;

    public void AddToInventory()
    {
        gameObject.SetActive(false);
        inventory.water.Add(this);
    }
}
