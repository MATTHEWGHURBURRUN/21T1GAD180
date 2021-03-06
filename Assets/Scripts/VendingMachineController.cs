using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineController : MonoBehaviour
{
    public bool isFixed;
    public Animator animator;
    public Transform teleportLocation;
    public GameObject eventObject;
    public float resetTimer;
    public bool timerRunning = false;

    public void FixVendingMachine()
    {
        if (!isFixed)
        {
            // Find the player and VendingMachine within the context of the game
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject vendingmachine = GameObject.FindGameObjectWithTag("VendingMachine");

            if (player != null)
            {
                // Stop the player from moving. Teleport the player to in front of the VendingMachine. Play the Punch Right animation. Call both couroutine functions of (WaitThreeSecondsPlayer(player)) and (WaitThreeSecondsPhone(VendingMachine))
                player.GetComponent<PlayerMovement>().movementFreedom = false;
                player.transform.position = teleportLocation.position;
                player.GetComponent<Animator>().Play("Punch Right");
                StartCoroutine(WaitThreeSecondsPlayer(player));
                StartCoroutine(WaitThreeSecondsPrinter(vendingmachine));
            }
            // Set the VendingMachine to fixed
            isFixed = true;
            Debug.Log("VendingMachine is now fixed.");
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

        resetTimer = Random.Range(12, 19);

        timerRunning = true;
    }

    // If timer is above 0, keep the VendingMachine fixed. If not, break the VendingMachine
    void Update()
    {
        if (timerRunning)
        {
            GameObject vendingmachine = GameObject.FindGameObjectWithTag("VendingMachine");
            if (resetTimer > 0)
            {
                resetTimer -= Time.deltaTime;

            }
            else
            {
                Debug.Log("VendingMachine Broke");
                resetTimer = 0;
                timerRunning = false;
                isFixed = false;
                vendingmachine.GetComponent<Animator>().Play("Broken Vending Machine");
            }
        }
    }

    //After 3 seconds have passed, fix VendingMachine
    IEnumerator WaitThreeSecondsPrinter(GameObject vendingmachine)
    {
        print("Start waiting");

        yield return new WaitForSeconds(3);

        print("3 seconds has passed");

        vendingmachine.GetComponent<Animator>().Play("Fixed Vending Machine");

    }
}
