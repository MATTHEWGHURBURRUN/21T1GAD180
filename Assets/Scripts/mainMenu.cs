using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
	public AudioSource explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            //Press the Return/Enter key in order to load the level "tutorialScene" from the built levels in the build settings.
          if (Input.GetKeyDown(KeyCode.Return))
          {
				explosionSound.Play();
                Application.LoadLevel("tutorialScene");

          }
        
    }
}
