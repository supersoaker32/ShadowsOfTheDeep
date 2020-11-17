using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    [SerializeField] SceneScript script = null;
    private float criticalPowerLevel = 5;
    private float lowPowerLevel = 15;
    private float highPower = 75;
    private float fullPower = -0.003f;
    private float midPower = -0.0006f;
    private float lowPower = -0.0005f;
    private float critPower = 0.0003f;
    private float noPower = 0.0001f;
    //Static decrease: 0.0005

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
                //Decrease insanity if high power level
                if (script.powerDisplay.value > highPower)
                {
                    Debug.Log($"Decrease insanity {fullPower} from having full power");
                    script.insanityDisplay.value += fullPower;
                }

                //Slowly decrease insanity if middle power level
                else if (script.powerDisplay.value < highPower && script.powerDisplay.value > lowPowerLevel)
                {
                    Debug.Log($"Increase insanity {midPower} from being below {highPower}");
                    script.insanityDisplay.value += midPower;
                }

                //No effect on insanity if low power level
                else if (script.powerDisplay.value > criticalPowerLevel && script.powerDisplay.value < lowPowerLevel)
                {
                    Debug.Log($"Increase insanity quickly {lowPower} from being below {lowPowerLevel}");
                    script.insanityDisplay.value += lowPower;
                }

                //Increase insanity if critcial power level
                else
                {
                    Debug.Log($"Increase insanity quickly {critPower} from being in critical power zone");
                    script.insanityDisplay.value += critPower;
                }
            }

            //Quickly increase insanity if power is off
            else
            {
                Debug.Log($"Decrease sanity very quickly {noPower} From having no power on, darkness is scary");
                script.insanityDisplay.value += noPower;
            }
        }
    }
}
