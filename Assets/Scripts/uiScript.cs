using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Timer code sourced from: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
public class uiScript : MonoBehaviour
{
    // All of the parts ready to move.
    public float timeRemaining = 60;
    public bool timerIsRunning = false;
    public Text timeText;
    public Text doodScore;
    public int punches;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        // A line to make sure the UI in the top left of the screen is loaded & visible on startup
        doodScore.text = "Objects Punched: " + punches.ToString();
        
    }

    void Update()
    {
        // Checking if the boolian is true
        if (timerIsRunning)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            // If the time remaning float is above 0. Continue to go down and update the UI to reflect this change.
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            // If the time remaning is not above 0. Set it to 0, change the bool to false and change the UI text to Time Out.
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                timeText.text = "Time Out";
                player.GetComponent<PlayerMovement>().movementFreedom = false;
            }
        }

        if (timeRemaining = 0) 
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().movementFreedom = false;
        }

        // Get the int and update the UI in the top left.
        doodScore.text = "Objects Punched: " + punches.ToString();
        
    }

    // Calculating the numbers to display. 
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{00}", seconds);
    }
}
