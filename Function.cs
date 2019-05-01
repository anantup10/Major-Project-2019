using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function : MonoBehaviour
{
    public TrafficLight traffic;
    public int i=0;

    // Start is called before the first frame update
    void Start()
    {
       traffic = GameObject.Find("TrafficLight").GetComponent<TrafficLight>();
    }

    // Update is called once per frame
    void Update()
    {
        i += 1;
        if (i % 30 == 0 && i > 30)
        {
            traffic.enabled =! traffic.enabled ;
            i = 0;
        }
    }
}
