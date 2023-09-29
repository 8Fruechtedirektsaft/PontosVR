using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeySocket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(keyTag) && RaiseKeyPlacedEvent != null)
        {  
            RaiseKeyPlacedEvent(this, new KeySocketEventArgs (keyTag));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(keyTag) && RaiseKeyDroppedEvent != null)
        {
            RaiseKeyDroppedEvent(this, new KeySocketEventArgs(keyTag));
        }
    }

    public delegate void KeySocketEventHandler(KeySocket sender, KeySocketEventArgs args);
    public event KeySocketEventHandler RaiseKeyPlacedEvent;
    public event KeySocketEventHandler RaiseKeyDroppedEvent;

    [SerializeField]
    private string keyTag;
}
