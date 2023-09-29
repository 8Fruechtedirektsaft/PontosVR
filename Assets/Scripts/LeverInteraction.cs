using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteraction : RotationInteractable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        }
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        float angleDif = AngleDifference();
        if(angleDif > 0.5 && angleDif < 4)
        {
            propellor.AddTorque(new Vector3(0, 0, 1) * angleDif * propellorRotation * Time.deltaTime, ForceMode.Acceleration);
            propelledBody.AddForce(propellDirection * angleDif * propellorPower * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    protected override float RelevantAxisAngle(Quaternion angle)
    {
        return angle.eulerAngles.x;
    }

    [SerializeField]
    private float propellorRotation;
    [SerializeField]
    private float propellorPower;
    [SerializeField]
    private Rigidbody propellor;
    [SerializeField]
    private Rigidbody propelledBody;
    [SerializeField]
    private Vector3 propellDirection;

}
