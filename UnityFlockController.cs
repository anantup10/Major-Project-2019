﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityFlockController : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 bound;
    public float speed = 100.0f;
    private Vector3 initialPosition;
    private Vector3 nextMovementPoint;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        CalculateNextMovementPoint();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(nextMovementPoint - transform.position), 1.0f * Time.deltaTime);
        if (Vector3.Distance(nextMovementPoint, transform.position) <= 10.0f)
            CalculateNextMovementPoint();
    }
    void CalculateNextMovementPoint()
    {
        float posX = Random.Range(initialPosition.x - bound.x, initialPosition.x + bound.x);
        float posY = initialPosition.y;
        float posZ = Random.Range(initialPosition.z - bound.z, initialPosition.z + bound.z);
        nextMovementPoint = initialPosition + new Vector3(posX, posY, posZ);
    }
}
