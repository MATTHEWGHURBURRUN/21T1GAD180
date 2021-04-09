using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrinterController : MonoBehaviour
{
    public bool isFixed;
    public Animator animator;

    public void FixPrinter() 
    {
        if (!isFixed)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) 
            {
                player.GetComponent<PlayerMovement>().movementFreedom = false;
                player.GetComponent<Animator>().Play("Punch Right");
                StartCoroutine(WaitThreeSeconds(player));
            }
            isFixed = true;
            Debug.Log("Printer is now fixed.");
        }
    }

    IEnumerator WaitThreeSeconds(GameObject player)
    {
        print("Start waiting");

        yield return new WaitForSeconds(3);

        player.GetComponent<PlayerMovement>().movementFreedom = true;

        print("3 seconds has passed");
    }
}
