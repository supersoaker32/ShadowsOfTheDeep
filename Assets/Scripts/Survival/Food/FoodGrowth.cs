using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodGrowth : MonoBehaviour
{
    [SerializeField] Slider[] progressBars = null;
    [SerializeField] Button button = null;
    [SerializeField] GameObject[] food = null;
    [SerializeField] Transform[] foodSpawn = null;

    [SerializeField] SceneScript scene = null;

    

    private bool power = false;
    void Update()
    {
        if (gameObject.activeSelf) power = true;

        if (power)
        {
            progressBars[0].value += 0.0007f;
            progressBars[1].value += 0.0005f;
            progressBars[2].value += 0.0001f;

            scene.powerLevel -= 0.005f;
            Debug.Log("Food draining power by .001f");
        }

        for(int i = 0; i < progressBars.Length; i++)
        {
            //When progressbars fill, spawn food at a location with random rotation
            if (progressBars[i].value >= 1)
            {
                int randomSpawn = Random.Range(0, foodSpawn.Length - 1);
                GameObject foodClone = Instantiate(food[i], foodSpawn[randomSpawn].transform.position, Random.rotation);
                foodClone.SetActive(true);
                Debug.Log($"Food spawned at spawn: {randomSpawn} with position {foodSpawn[randomSpawn].transform.position}");
                progressBars[i].value = 0;
            }
        }
    }

    public void PowerSwitch()
    {
        power = !power;
    }
}
