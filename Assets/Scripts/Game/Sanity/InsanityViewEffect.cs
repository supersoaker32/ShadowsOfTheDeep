using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InsanityViewEffect : MonoBehaviour
{
    [SerializeField] Volume vol = null;
    [SerializeField] SceneScript script = null;

    private void Start()
    {
        vol.enabled = true;
    }

    //Provides visual effect based on insanity level
    private void Update()
    {
        vol.weight = script.insanityDisplay.value / 100;
    }
}
