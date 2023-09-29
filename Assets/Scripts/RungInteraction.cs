using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RungInteraction : RotationInteractable
{
    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (waterLevelTrigger.position.y < waterLevel.position.y + emergeHeight)
        {
            propelledBody.AddForce(new Vector3(0, 1, 0) * RotationDirection() * AngleDifference() * rungAcceleration * Time.deltaTime, ForceMode.Acceleration);
        }
        else
        {
            propelledBody.AddForce(new Vector3(0, -1, 0) * sinkingSpeed * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    protected override float RelevantAxisAngle(Quaternion angle)
    {
        return angle.eulerAngles.y;
    }

    [SerializeField]
    private Rigidbody propelledBody;
    [SerializeField]
    private float rungAcceleration;
    [SerializeField]
    private Transform waterLevelTrigger;
    [SerializeField]
    private Transform waterLevel;
    [SerializeField]
    private float emergeHeight;
    [SerializeField]
    private float sinkingSpeed;
}
