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
            
            isFixed = true;
            Debug.Log("Printer is now fixed.");
            animator.SetBool("Is fixed.", isFixed);
        }
    }
}
