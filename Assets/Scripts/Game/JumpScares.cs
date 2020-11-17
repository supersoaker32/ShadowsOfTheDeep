using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScares : MonoBehaviour
{
    [SerializeField] SceneScript scene = null;
    [SerializeField] AudioSource[] smallScareSounds = null;
    [SerializeField] GameObject[] monsters = null;
    [SerializeField] GameObject player = null;

    private GameObject currentScare = null;

    bool scareActive = false;

    private void Update()
    {
        if (scareActive)
        {
            SmallScareHide(currentScare);
        }
    }

    public void ScareCalc()
    {
        float rng = Random.Range(0.0f, 1.0f);
        float chance = scene.insanityDisplay.value * rng;
        Debug.Log(chance);
        if (chance > 4.0f && chance <= 8.5f)
        {
            Debug.Log("Small scare");
        }
        else if (chance > 8.5f && chance <= 9.5f)
        {
            Debug.Log("Medium scare");
        }
        else if (chance > 9.5f)
        {
            Debug.Log("Large scare");
        }
    }

    public void SmallScareHide(GameObject scare)
    {
        Vector3 forward = player.transform.forward;
        Debug.Log($"player's forward = {forward.x}, {forward.y}, {forward.z}");
        Vector3 direction = scare.transform.position - forward;
        Debug.Log($"direction = {direction.x}, {direction.y}, {direction.z}");
        direction.y = 0;
        if(Vector3.Angle(forward, direction) < 45)
        {
            scare.SetActive(false);
            scareActive = false;
            Debug.Log("Player looked at scare");
        }
    }

    public IEnumerator MonsterJumpScare(GameObject monster, AudioSource scareSound, float seconds)
    {
        //Get camera position
        Vector3 screenDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //Spawn monster on left or right randomly
        int choose = UnityEngine.Random.Range(0, 1);
        int z = choose == 0 ? 1 : -1;

        //Set position for monster jump scare
        Vector3 position = screenDimensions + new Vector3(0, 0, z);
        position.y = 0;
        monster.transform.position = position;

        //Activate jumpscare, disable monster after seconds
        monster.SetActive(true);
        scareSound.Play();
        currentScare = monster;
        scareActive = true;
        yield return new WaitForSeconds(seconds);
        monster.SetActive(false);
        scareSound.Stop();
    }

    public IEnumerator AudioJumpScare(AudioSource scareSound)
    {
        //Get camera position
        Vector3 screenDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //Spawn monster on left or right randomly
        int choose = Random.Range(0, 1);
        int z = choose == 0 ? 1 : -1;

        //Set position for monster jump scare
        Vector3 position = screenDimensions + new Vector3(0, 0, z);
        position.y = 0;

        //Activate jumpscare, disable monster after seconds
        scareSound.Play();
        scareSound.Stop();
        yield return new WaitForSeconds(0);
    }
}
