using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrinterController : MonoBehaviour
{
    public bool isFixed;
    public Animator animator;
    public Transform teleportLocation;
    public GameObject eventObject;
    public float resetTimer;
    public bool timerRunning = false;

    public void FixPrinter() 
    {
        if (!isFixed)
        {
            // Find the player and Printer within the context of the game
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject printer = GameObject.FindGameObjectWithTag("Printer");
            
            if (player != null) 
            {
                // Stop the player from moving. Teleport the player to in front of the printer. Play the Punch Right animation. Call both couroutine functions of (WaitThreeSecondsPlayer(player)) and (WaitThreeSecondsPhone(printer))
                player.GetComponent<PlayerMovement>().movementFreedom = false;
                player.transform.position = teleportLocation.position;
                player.GetComponent<Animator>().Play("Punch Right");
                StartCoroutine(WaitThreeSecondsPlayer(player));
                StartCoroutine(WaitThreeSecondsPrinter(printer));
            }
            //Set the Printer to fixed
            isFixed = true;
            Debug.Log("Printer is now fixed.");
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

        resetTimer = Random.Range(8, 15);

        timerRunning = true;
    }

    // If timer is above 0, keep the Printer fixed. If not, break the Printer
    void Update()
    {
        if (timerRunning)
        {
            GameObject printer = GameObject.FindGameObjectWithTag("Printer");
            if (resetTimer > 0)
            {
                resetTimer -= Time.deltaTime;
               
            }
            else
            {
                Debug.Log("Printer Broke");
                resetTimer = 0;
                timerRunning = false;
                isFixed = false;
                printer.GetComponent<Animator>().Play("Broken Printer");
            }
        }
    }

    //After 3 seconds have passed, fix Printer
    IEnumerator WaitThreeSecondsPrinter(GameObject printer)
    {
        print("Start waiting");

        yield return new WaitForSeconds(3);

        print("3 seconds has passed");

        printer.GetComponent<Animator>().Play("Fixed Printer");

    }
}
