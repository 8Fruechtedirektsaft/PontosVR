using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedBreak : MonoBehaviour
{
    private void OnJointBreak(float breakForce)
    {
        gameObject.layer = default;
    }
}
