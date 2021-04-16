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
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject phone2 = GameObject.FindGameObjectWithTag("Phone 2");

            if (player != null)
            {
                player.GetComponent<PlayerMovement>().movementFreedom = false;
                player.transform.position = teleportLocation.position;
                player.GetComponent<Animator>().Play("Punch Right");
                StartCoroutine(WaitThreeSecondsPlayer(player));
                StartCoroutine(WaitThreeSecondsPhone(phone2));
            }
            isFixed = true;
            Debug.Log("Phone 2 is now fixed.");
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

        resetTimer = Random.Range(1, 30);

        timerRunning = true;
    }

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

    IEnumerator WaitThreeSecondsPhone(GameObject phone)
    {
        print("Start waiting");

        yield return new WaitForSeconds(3);

        print("3 seconds has passed");

        phone.GetComponent<Animator>().Play("Fixed Phone");

    }
}