using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiScript : MonoBehaviour
{
    
    public float timeRemaining = 30;
    public bool timerIsRunning = false;
    public Text timeText;
    public Text doodScore;
    public int punches;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;

        doodScore.text = "Objects Punched: " + punches.ToString();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                timeText.text = "Time Out";
            }
        }
      
      

       doodScore.text = "Objects Punched: " + punches.ToString();
        
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{00}", seconds);
    }
}
