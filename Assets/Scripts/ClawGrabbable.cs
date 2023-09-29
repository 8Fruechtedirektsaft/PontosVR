using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClawGrabbable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Claw") && GrabbedEvent != null)
        {
            GrabbedEvent();
        }
    }

    public event GrabbedDelegate GrabbedEvent; 
    public delegate void GrabbedDelegate();
}
