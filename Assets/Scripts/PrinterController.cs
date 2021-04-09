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
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject printer = GameObject.FindGameObjectWithTag("Printer");
            
            if (player != null) 
            {
                player.GetComponent<PlayerMovement>().movementFreedom = false;
                player.transform.position = teleportLocation.position;
                player.GetComponent<Animator>().Play("Punch Right");
                StartCoroutine(WaitThreeSecondsPlayer(player));
                StartCoroutine(WaitThreeSecondsPrinter(printer));
            }
            isFixed = true;
            Debug.Log("Printer is now fixed.");
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

    IEnumerator WaitThreeSecondsPrinter(GameObject printer)
    {
        print("Start waiting");

        yield return new WaitForSeconds(3);

        print("3 seconds has passed");

        printer.GetComponent<Animator>().Play("Fixed Printer");

    }
}
