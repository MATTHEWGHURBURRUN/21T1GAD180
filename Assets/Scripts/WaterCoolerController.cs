using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCoolerController : MonoBehaviour
{
    public bool isFixed;
    public Animator animator;
    public Transform teleportLocation;
    public GameObject eventObject;
    public float resetTimer;
    public bool timerRunning = false;

    public void FixWaterCooler()
    {
        if (!isFixed)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject watercooler = GameObject.FindGameObjectWithTag("WaterCooler");

            if (player != null)
            {
                player.GetComponent<PlayerMovement>().movementFreedom = false;
                player.transform.position = teleportLocation.position;
                player.GetComponent<Animator>().Play("Punch Right");
                StartCoroutine(WaitThreeSecondsPlayer(player));
                StartCoroutine(WaitThreeSecondsWaterCooler(watercooler));
            }
            isFixed = true;
            Debug.Log("WaterCooler is now fixed.");
        }
    }

    IEnumerator WaitThreeSecondsPlayer(GameObject player)
    {
        print("Start waiting");

        yield return new WaitForSeconds(3);

        player.GetComponent<PlayerMovement>().movementFreedom = true;

        print("3 seconds has passed");

        eventObject = GameObject.FindGameObjectWithTag("uiTag");

        eventObject.GetComponent<uiScript>().punches += 1;

        resetTimer = Random.Range(4, 10);

        timerRunning = true;
    }

    void Update()
    {
        if (timerRunning)
        {
            GameObject watercooler = GameObject.FindGameObjectWithTag("WaterCooler");
            if (resetTimer > 0)
            {
                resetTimer -= Time.deltaTime;

            }
            else
            {
                Debug.Log("WaterCooler Broke");
                resetTimer = 0;
                timerRunning = false;
                isFixed = false;
                watercooler.GetComponent<Animator>().Play("Broken WaterCooler");
            }
        }
    }

    IEnumerator WaitThreeSecondsWaterCooler(GameObject watercooler)
    {
        print("Start waiting");

        yield return new WaitForSeconds(3);

        print("3 seconds has passed");

        watercooler.GetComponent<Animator>().Play("Fixed WaterCooler");

    }
}