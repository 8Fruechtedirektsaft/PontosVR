
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    private void Start()
    {
        randomTime = Random.Range(10, 20);
        timeCounter = 0;
    }

    private void FixedUpdate()
    {
        FaceRandomDirection();
        Vector3 direction = FindUnobstructedDirection();
        //Debug.DrawRay(transform.position, direction, Color.yellow);
        transform.LookAt(transform.position + direction);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //Debug.DrawRay(transform.position, transform.forward * collisionDistance, Color.blue);
    }

    private Vector3 FindUnobstructedDirection()
    {
        Vector3[] rayDirections = new Vector3[5];
        rayDirections[0] = transform.forward;
        rayDirections[1] = Quaternion.AngleAxis(20, transform.right) * transform.forward;
        rayDirections[2] = Quaternion.AngleAxis(-20, transform.right) * transform.forward;
        rayDirections[3] = Quaternion.AngleAxis(20, transform.up) * transform.forward;
        rayDirections[4] = Quaternion.AngleAxis(-20, transform.up) * transform.forward;
        RaycastHit hit;
        List<Vector3> unobstructedDirections = new List<Vector3>();
        Vector3 maxObstructedDirection = transform.forward;
        float maxHitDistance = 0;
        for (int i = 0; i < rayDirections.Length; i++)
        {
            if (!Physics.Raycast(transform.position, rayDirections[i], out hit, detectionRange, layerMask))
            {
                unobstructedDirections.Add(rayDirections[i]);
                //Debug.DrawRay(transform.position, rayDirections[i] * detectionRange, Color.green);
            }
            else
            {
                if (hit.distance >= maxHitDistance)
                {
                    maxHitDistance = hit.distance;
                    maxObstructedDirection = rayDirections[i];
                }
                //Debug.DrawRay(transform.position, rayDirections[i] * hit.distance, Color.red);
            }
        }
        if (unobstructedDirections.Count == 0)
        {
            if (maxHitDistance <= turnDistance)
            {
                maxObstructedDirection *= -1;
            }
            return maxObstructedDirection;
        }
        else
        {
            Vector3 unobstructedDirection = Vector3.zero;
            foreach (Vector3 direction in unobstructedDirections)
            {
                unobstructedDirection += direction; 
            }
            return unobstructedDirection.normalized;
        }
    }

    private void FaceRandomDirection()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= randomTime)
        {
            Vector3 randomDirection = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
            transform.LookAt(transform.position + randomDirection.normalized);
            randomTime = Random.Range(10, 20);
            timeCounter = 0;
        }
    }

    private float randomTime;
    private float timeCounter;
    [SerializeField]
    private float speed;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float detectionRange;
    [SerializeField]
    private float turnDistance;
}
