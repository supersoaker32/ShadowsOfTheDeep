using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    [SerializeField] SceneScript script = null;
    private float criticalPower = 5;
    private float lowPower = 15;
    private float highPower = 75;
    private float dInsanity = -0.003f;
    private float iSlow = 0.0005f;
    private float iQuick = 0.001f;
    private float iVQuick = 0.004f;

    private void OnTriggerStay(Collider other)
    {
        SanityEffect(other);
    }

    private void SanityEffect(Collider other)
    {
        //If the player is within the area, effect sanity
        if (other.CompareTag("PlayerLeft") || other.CompareTag("PlayerRight"))
        {
            //If there's power effect insanity
            if (script.power)
            {
                //Increase sanity if safe power level
                if (script.powerLevel > highPower)
                {
                    Debug.Log("Increase sanity" + dInsanity);
                    script.sanityDisplay.value += dInsanity;
                }

                //Slow decrease within moderate range
                else if (script.powerLevel < highPower && script.powerLevel > lowPower)
                {
                    Debug.Log("Decrease sanity" + iSlow);
                    script.sanityDisplay.value += iSlow;
                }

                //Drastically decrease within low range
                else if (script.powerLevel > criticalPower && script.powerLevel < lowPower)
                {
                    Debug.Log("Decrease sanity quickly" + iQuick);
                    script.sanityDisplay.value += iQuick;
                }

                //Very drastically decrease within critical range
                else
                {
                    Debug.Log("Decrease sanity quickly" + iVQuick);
                    script.sanityDisplay.value += iVQuick;
                }
            }

            //Very drastically decrease if off
            else
            {
                Debug.Log("Decrease sanity very quickly" + iVQuick);
                script.sanityDisplay.value += iVQuick;
            }
        }
    }
}
