using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandrable : MonoBehaviour
{
    private Vector3 tarpos;
    private float movementSpeed = 5.0f;
    private float rotSpeed = 2.0f;
    private float minX, maxX, minZ, maxZ;

    // Start is called before the first frame update
    void Start()
    {
        minX = -45.0f;
        maxX = 45.0f;

        minZ = -45.0f;
        maxZ = 45.0f;
        GetNextPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(tarpos, transform.position) <= 5.0f)
        {
            GetNextPosition();
        }
        Quaternion tarRot = Quaternion.LookRotation(tarpos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, rotSpeed * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));
    }
    void GetNextPosition()
    {
        tarpos = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ));
    }
}
