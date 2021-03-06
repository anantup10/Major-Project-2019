﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFollowing2 : MonoBehaviour
{

    public Patha path;
    public float speed = 20.0f;
    public float mass = 5.0f;
    public bool isLooping = true;
    public TrafficLight traffic;
    private float curSpeed;
    private int curPathIndex;
    private float pathLength;
    private Vector3 targetPoint;
    private Rigidbody rigidbody;
    Vector3 velocity;
    Animator animator;
    public enum AISTATE { HumanoidIdle = 0, walk = 1};
    [SerializeField]
    public AISTATE myActiveState = AISTATE.HumanoidIdle;
    // Start is called before the first frame update
    void Start()
    {
        pathLength = path.Length;
        curPathIndex = 0;
        velocity = transform.forward;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        curSpeed = speed * Time.deltaTime;
        targetPoint = path.GetPoint(curPathIndex);
        if (Vector3.Distance(transform.position, targetPoint) < path.Radius)
        {
            if (curPathIndex < pathLength - 1) curPathIndex++;
            else if (isLooping) curPathIndex = 0;
            else return;
        }
        if (curPathIndex >= pathLength) return;
        if (curPathIndex >= pathLength - 1 && isLooping)
            velocity += Steer(targetPoint);
        else velocity += Steer(targetPoint);
        transform.position += velocity;
        transform.rotation = Quaternion.LookRotation(velocity);

     
    }

    public Vector3 Steer(Vector3 target, bool bfinalPoint = false)
    {
        Vector3 desiredVelocity = (target - transform.position);
        float dist = desiredVelocity.magnitude;
        desiredVelocity.Normalize();
        if (bfinalPoint && dist < 10.0f) desiredVelocity *= (curSpeed * (dist / 10.0f));
        else desiredVelocity *= curSpeed;
        Vector3 steeringForce = desiredVelocity - velocity;
        Vector3 acceleration = steeringForce / mass;
        return acceleration;
        transform.rotation = Quaternion.LookRotation(transform.forward);
    }
}
