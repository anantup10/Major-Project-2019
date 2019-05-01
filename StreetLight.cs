using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLight : MonoBehaviour
{
    public Color MyColor;
    public Color MyColore;
    public MeshRenderer myRenderer;
    public DayNightCycle Intensity;
    private Light lightComponent;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        lightComponent = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Intensity.intensity >= 180)
        {
            myRenderer.material.color = MyColor;
            lightComponent.enabled = true ;
        }
        else
        {
            myRenderer.material.color = MyColore;
            lightComponent.enabled = false;
        }
       

    }
}