using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tempel : MonoBehaviour
{
    private void Start()
    {
        foreach (KeySocket keySocket in keySockets)
        {
            keySocket.RaiseKeyPlacedEvent += HandleKeyPlacedEvent;
        }   
    }

    private void HandleKeyPlacedEvent(KeySocket sender, KeySocketEventArgs e)
    {
        KeyPlaced();
        sender.RaiseKeyPlacedEvent -= HandleKeyPlacedEvent;
        sender.RaiseKeyDroppedEvent += HandleKeyDroppedEvent;
    }

    private void HandleKeyDroppedEvent(KeySocket sender, KeySocketEventArgs e)
    {
        KeyDropped();
        sender.RaiseKeyPlacedEvent += HandleKeyPlacedEvent;
        sender.RaiseKeyDroppedEvent -= HandleKeyDroppedEvent;
    }

    private void RaiseGameObject(GameObject gameObject)
    {
        gameObject.transform.Translate(new Vector3(0, 20, 0));
    }

    private void LowerGameObject(GameObject gameObject)
    {
        gameObject.transform.Translate(new Vector3(0, -20, 0));
    }

    private void KeyPlaced()
    {
        amountKeysPlaced++;
        if (amountKeysPlaced == 1)
        {
            RaiseGameObject(frontObject);
        }
        else if (amountKeysPlaced == 2)
        {
            RaiseGameObject(backObject);
        }
        else if (amountKeysPlaced == 3)
        {
            RaiseGameObject(middleObject);
        }
    }

    private void KeyDropped()
    {
        if (amountKeysPlaced == 1)
        {
            LowerGameObject(frontObject);
        }
        else if (amountKeysPlaced == 2)
        {
            LowerGameObject(backObject);
        }
        else if (amountKeysPlaced == 3)
        {
            LowerGameObject(middleObject);
        }
        amountKeysPlaced--;
    }

    private int amountKeysPlaced = 0;
    [SerializeField]
    private KeySocket[] keySockets;
    [SerializeField]
    private GameObject frontObject;
    [SerializeField]
    private GameObject backObject;
    [SerializeField]
    private GameObject middleObject;
}
