using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraFollow : MonoBehaviour
{
    void Update()
    {
        Vector3 position = followTransform.position;
        position.x += 8.5f;
        position.y += 2.5f;
        position.z += 10.5f;
        this.GetComponent <Transform>().position = position; 
    }

    [SerializeField]
    private Transform followTransform;
}
