using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sceneChange : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Press the Return/Enter key in order to load the level "testo2" from the built levels in the build settings.
        if (Input.GetKeyDown(KeyCode.Return))
        {

            Application.LoadLevel("testo2");

        }
    }
}
