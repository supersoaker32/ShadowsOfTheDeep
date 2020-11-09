using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public List<Battery> batteries = new List<Battery>();
    [HideInInspector] public List<string> food = new List<string>();
    [HideInInspector] public List<string> water = new List<string>();
}
