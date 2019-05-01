using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DayNightCycle : MonoBehaviour
{
    public float speed = 10.0f;
    public event System.EventHandler OnChanged;
    float dayDuration;
    public bool isNight { get; private set; }
    private Color dayColor;
    private Light lightComponent;
    public float intensity;
    
    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();
        dayColor = lightComponent.color;
    }

    // Update is called once per frame
    public void Update()
    {
        dayDuration = 360 / speed;

        Color nighColor = Color.white * 0.1f;
        float lightIntensity = 0.5f + Mathf.Sin(Time.time * 2.0f * Mathf.PI / dayDuration) / 2.0f;
        if (isNight != (lightIntensity < 0.3))
        {
            isNight = !isNight;
            if (OnChanged != null)
            {
                OnChanged(this, System.EventArgs.Empty);
                
            }
           
        }
        lightComponent.color = Color.Lerp(nighColor, dayColor, lightIntensity);
        transform.Rotate(0f, 0f, speed * Time.deltaTime, Space.World);
        intensity = transform.eulerAngles.x;
    }
}
