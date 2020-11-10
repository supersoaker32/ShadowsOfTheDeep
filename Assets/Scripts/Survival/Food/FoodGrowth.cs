using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodGrowth : MonoBehaviour
{
    [SerializeField] Slider[] progressBars = null;
    [SerializeField] Button button = null;

    [SerializeField] SceneScript scene = null;

    private bool power = false;
    void Update()
    {
        if (power)
        {
            progressBars[0].value += 0.001f;
            progressBars[1].value += 0.0005f;
            progressBars[2].value += 0.0001f;
        }
    }

    public void PowerSwitch()
    {
        power = !power;
    }
}
