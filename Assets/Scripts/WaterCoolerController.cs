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
            // Find the player and WaterCooler within the context of the game
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject watercooler = GameObject.FindGameObjectWithTag("WaterCooler");

            if (player != null)
            {
                // Stop the player from moving. Teleport the player to in front of the WaterCooler. Play the Punch Right animation. Call both couroutine functions of (WaitThreeSecondsPlayer(player)) and (WaitThreeSecondsPhone(WaterCooler))
                player.GetComponent<PlayerMovement>().movementFreedom = false;
                player.transform.position = teleportLocation.position;
                player.GetComponent<Animator>().Play("Punch Right");
                StartCoroutine(WaitThreeSecondsPlayer(player));
                StartCoroutine(WaitThreeSecondsWaterCooler(watercooler));
            }
            // Set the WaterCooler to fixed
            isFixed = true;
            Debug.Log("WaterCooler is now fixed.");
        }
    }

    // Pause player movement for 3 seconds. Then unlock player movement, update the punch score and run a timer to have the object break again at some point in the future.
    IEnumerator WaitThreeSecondsPlayer(GameObject player)
    {
        print("Start waiting");

        yield return new WaitForSeconds(3);

        player.GetComponent<PlayerMovement>().movementFreedom = true;

        print("3 seconds has passed");

        eventObject = GameObject.FindGameObjectWithTag("uiTag");

        eventObject.GetComponent<uiScript>().punches += 1;

        resetTimer = Random.Range(3, 20);

        timerRunning = true;
    }

    // If timer is above 0, keep the WaterCooler fixed. If not, break the WaterCooler
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

    //After 3 seconds have passed, fix WaterCooler
    IEnumerator WaitThreeSecondsWaterCooler(GameObject watercooler)
    {
        print("Start waiting");

        yield return new WaitForSeconds(3);

        print("3 seconds has passed");

        watercooler.GetComponent<Animator>().Play("Fixed WaterCooler");

    }
}