﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sense : MonoBehaviour
{
    public bool bDebug = true;
    public Aspect.aspect aspectName = Aspect.aspect.Enemy;
    public float detectionRate = 1.0f;
    protected float elapsedTime = 0.0f;
    protected virtual void Initialize()
    {

    }
    protected virtual void UpdateSense()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f;
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSense();
    }
}
