using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void FixPrinter();

    public static event FixPrinter OnFixPrinter;

    public static void PunchPrinter()
    {
        OnFixPrinter();
    }
}
