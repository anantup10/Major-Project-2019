using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : Sense
{
    public int FieldOfView = 45;
    public int ViewDistance = 100;
    private Transform playerTrans;
    private Vector3 rayDirection;
    protected override void Initialize()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void UpdateSense()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= detectionRate)
            DetectAspect();
    }

    void DetectAspect()
    {
        RaycastHit hit;
        rayDirection = playerTrans.position - transform.position;
        if((Vector3.Angle(rayDirection, transform.forward )) < FieldOfView)
        {
            if(Physics.Raycast(transform.position, rayDirection, out hit, ViewDistance))
            {
                Aspect aspect = hit.collider.GetComponent<Aspect>();
                if (aspect!= null)
                {
                    if(aspect.aspectName == aspectName)
                    {
                        Debug.Log("Enemy Detected");
                    }
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (!Application.isEditor || playerTrans == null)
            return;
        Debug.DrawLine(transform.position, playerTrans.position, Color.red);
        Vector3 frontRayPOint = transform.position + (transform.forward * ViewDistance);
        Vector3 leftRayPoint = Quaternion.Euler(0, FieldOfView * 0.5f, 0) * frontRayPOint;
        Vector3 rightRayPoint = Quaternion.Euler(0, -FieldOfView * 0.5f, 0) * frontRayPOint;
        Debug.DrawLine(transform.position, frontRayPOint, Color.green);
        Debug.DrawLine(transform.position, leftRayPoint, Color.green);
        Debug.DrawLine(transform.position, rightRayPoint, Color.green);
    }
}
