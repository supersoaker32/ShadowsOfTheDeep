using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public List<Battery> batteries = new List<Battery>();
    [HideInInspector] public List<Food> food = new List<Food>();
    [HideInInspector] public List<Water> water = new List<Water>();
}
