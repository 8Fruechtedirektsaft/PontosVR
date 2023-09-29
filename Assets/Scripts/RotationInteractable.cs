using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RotationInteractable : MonoBehaviour
{
    protected void Start()
    {
        newAngle = RelevantAxisAngle(interactableObject.transform.localRotation);
    }

    protected void FixedUpdate()
    {
        lastAngle = newAngle;
        newAngle = RelevantAxisAngle(interactableObject.transform.localRotation);
    }

    protected float AngleDifference()
    {
        return Mathf.Abs(lastAngle - newAngle);
    }

    protected abstract float RelevantAxisAngle(Quaternion angle);

    protected float RotationDirection()
    {
        if (lastAngle < newAngle)
        {
            if (newAngle - lastAngle >= 180)
            {
                return 0;
            }
            return -1;
        }
        else if (lastAngle > newAngle)
        {
            if (lastAngle - newAngle >= 180)
            {
                return 0;
            }
            return 1;
        }
        return 0;
    }

    protected float lastAngle;
    protected float newAngle;
    [SerializeField]
    protected GameObject interactableObject;
}
