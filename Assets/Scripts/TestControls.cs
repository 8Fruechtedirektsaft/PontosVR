using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControls : MonoBehaviour
{
    private void FixedUpdate()
    {
        //Rung
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Rung.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Rung.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(0, -1, 0));
        }

        //Crank
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Crank1.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(0, -1, 0));
            Crank2.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(0, -1, 0));
            Crank3.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(0, -1, 0));
            Crank4.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(0, -1, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Crank1.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(0, 1, 0));
            Crank2.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(0, 1, 0));
            Crank3.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(0, 1, 0));
            Crank4.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(0, 1, 0));
        }

        //lever
        if (Input.GetKey(KeyCode.A))
        {
            Lever1.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(-1.5f, 0, 0));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Lever1.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(1.5f, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            Lever2.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(-1.5f, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            Lever2.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(1.5f, 0, 0));
        }
        if (Input.GetKey(KeyCode.E))
        {
            Lever3.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(-1.5f, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Lever3.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(1.5f, 0, 0));
        }
        if (Input.GetKey(KeyCode.R))
        {
            Lever4.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(-1.5f, 0, 0));
        }
        if (Input.GetKey(KeyCode.F))
        {
            Lever4.GetComponent<Rigidbody>()?.AddRelativeTorque(new Vector3(1.5f, 0, 0));
        }
    }

    public GameObject Lever1;
    public GameObject Lever2;
    public GameObject Lever3;
    public GameObject Lever4;

    public GameObject Crank1;
    public GameObject Crank2;
    public GameObject Crank3;
    public GameObject Crank4;

    public GameObject Rung;
}
