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
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject vendingmachine = GameObject.FindGameObjectWithTag("VendingMachine");

            if (player != null)
            {
                player.GetComponent<PlayerMovement>().movementFreedom = false;
                player.transform.position = teleportLocation.position;
                player.GetComponent<Animator>().Play("Punch Right");
                StartCoroutine(WaitThreeSecondsPlayer(player));
                StartCoroutine(WaitThreeSecondsPrinter(vendingmachine));
            }
            isFixed = true;
            Debug.Log("VendingMachine is now fixed.");
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

        resetTimer = Random.Range(12, 19);

        timerRunning = true;
    }

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

    IEnumerator WaitThreeSecondsPrinter(GameObject vendingmachine)
    {
        print("Start waiting");

        yield return new WaitForSeconds(3);

        print("3 seconds has passed");

        vendingmachine.GetComponent<Animator>().Play("Fixed Vending Machine");

    }
}
