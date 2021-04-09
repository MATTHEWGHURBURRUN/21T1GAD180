using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject theCharacter;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Punch"))
        {
            theCharacter.GetComponent<Animator>().Play("Punch Right");
        }
    }
}