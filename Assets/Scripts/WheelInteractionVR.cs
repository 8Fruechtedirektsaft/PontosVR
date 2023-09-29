using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WheelInteractionVR : XRBaseInteractable
{
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic && isSelected)
        {
            transform.LookAt(interactorsSelecting[0].transform.position);
            transform.rotation = Quaternion.Euler(0 , transform.rotation.eulerAngles.y, 0);
        }
    }
}
