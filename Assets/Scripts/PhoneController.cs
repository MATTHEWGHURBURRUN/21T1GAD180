using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public bool isFixed;
    public Animator animator;
    public Transform teleportLocation;
    public GameObject eventObject;
    public float resetTimer;
    public bool timerRunning = false;

    public void FixPhone()
    {
        if (!isFixed)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject phone = GameObject.FindGameObjectWithTag("Phone");

            if (player != null)
            {
                player.GetComponent<PlayerMovement>().movementFreedom = false;
                player.transform.position = teleportLocation.position;
                player.GetComponent<Animator>().Play("Punch Left");
                StartCoroutine(WaitThreeSecondsPlayer(player));
                StartCoroutine(WaitThreeSecondsPhone(phone));
            }
            isFixed = true;
            Debug.Log("Phone is now fixed.");
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

        resetTimer = Random.Range(9, 17);

        timerRunning = true;
    }

    void Update()
    {
        if (timerRunning)
        {
            GameObject phone = GameObject.FindGameObjectWithTag("Phone");
            if (resetTimer > 0)
            {
                resetTimer -= Time.deltaTime;

            }
            else
            {
                Debug.Log("Phone Broke");
                resetTimer = 0;
                timerRunning = false;
                isFixed = false;
                phone.GetComponent<Animator>().Play("Broken Phone");
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