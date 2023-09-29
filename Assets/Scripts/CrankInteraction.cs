using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankInteraction : RotationInteractable
{
    private new void Start()
    {
        base.Start();
        clawJoint = claw.GetComponent<HingeJoint>();
        clawRigidbody = claw.GetComponent<Rigidbody>();
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (AngleDifference() > 0.2)
        {
            clawRigidbody.constraints = RigidbodyConstraints.None;
            JointMotor jointMotor = clawJoint.motor;
            float targetVelocity = AngleDifference() * RotationDirection() * crankToClawSpeed * Time.deltaTime;
            jointMotor.targetVelocity = targetVelocity;
            clawJoint.useMotor = true;
            clawJoint.motor = jointMotor;
        }
        else
        {
            clawRigidbody.constraints = RigidbodyConstraints.FreezeRotationX;
            clawRigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
            clawRigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
            clawJoint.useMotor = false;
        }
    }

    protected override float RelevantAxisAngle(Quaternion angle)
    {
        return angle.eulerAngles.y;
    }

    private HingeJoint clawJoint;
    private Rigidbody clawRigidbody;
    [SerializeField]
    private GameObject claw;
    [SerializeField]
    private float crankToClawSpeed;
}
