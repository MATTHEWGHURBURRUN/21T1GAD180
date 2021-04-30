using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone2Controller : MonoBehaviour
{
    public bool isFixed;
    public Animator animator;
    public Transform teleportLocation;
    public GameObject eventObject;
    public float resetTimer;
    public bool timerRunning = false;

    public void FixPhone2()
    {
        if (!isFixed)
        {
            // Find the player and Phone 2 within the context of the game
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject phone2 = GameObject.FindGameObjectWithTag("Phone 2");

            if (player != null)
            {
                // Stop the player from moving. Teleport the player to in front of the phone. Play the Punch Right animation. Call both couroutine functions of (WaitThreeSecondsPlayer(player)) and (WaitThreeSecondsPhone(phone2))
                player.GetComponent<PlayerMovement>().movementFreedom = false;
                player.transform.position = teleportLocation.position;
                player.GetComponent<Animator>().Play("Punch Right");
                StartCoroutine(WaitThreeSecondsPlayer(player));
                StartCoroutine(WaitThreeSecondsPhone(phone2));
            }
            //Set the Phone 2 to fixed
            isFixed = true;
            Debug.Log("Phone 2 is now fixed.");
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

        resetTimer = Random.Range(1, 30);

        timerRunning = true;
    }

    // If timer is above 0, keep the Phone 2 fixed. If not, break the Phone 2.
    void Update()
    {
        if (timerRunning)
        {
            GameObject phone2 = GameObject.FindGameObjectWithTag("Phone 2");
            if (resetTimer > 0)
            {
                resetTimer -= Time.deltaTime;

            }
            else
            {
                Debug.Log("Phone 2 Broke");
                resetTimer = 0;
                timerRunning = false;
                isFixed = false;
                phone2.GetComponent<Animator>().Play("Broken Phone");
            }
        }
    }

    //After 3 seconds have passed, fix Phone 2
    IEnumerator WaitThreeSecondsPhone(GameObject phone)
    {
        print("Start waiting");

        yield return new WaitForSeconds(3);

        print("3 seconds has passed");

        phone.GetComponent<Animator>().Play("Fixed Phone");

    }
}