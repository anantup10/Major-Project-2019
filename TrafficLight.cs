using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public Color MyColor;
    public Color MyColore;
    public MeshRenderer myRenderer;
    public int i = 0;
    public int f;
    public int e;
    public float Locx;
    public float locy;
    public float locxx;
    public float locyy;
    public VehicleFollowing[] vehicle;
    public VehicleFollowing2[] humans;   
    private void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        for (int g = 0; g <= f - 1; g++)
        {
            vehicle[g] = GameObject.Find("VehicleFollowing").GetComponent<VehicleFollowing>();
        }
        for(int p = 0; p<=e-1; p++)
        {
            humans[p] = GameObject.Find("VehicleFollowing2").GetComponent<VehicleFollowing2>();
        }
    }

    private void Update()
    {
        i += 1;
        for (int g=0; g<=f-1; g++)
        {
            Action(g);
            
        }

        for (int p= 0; p <= e - 1; p++)
        {
            Human(p);

        }
    }
    public bool inRange(float c, float a, float b)
    {
        
       
        if(c>a && c < b)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   public void Action(int n)
    {
     
        if (i > 50)
        {
            myRenderer.material.color = MyColor;
            if (inRange(vehicle[n].transform.position.z, Locx, locy) && inRange(vehicle[n].transform.position.x, locxx, locyy)  && myRenderer.material.color == MyColor)
            {

                vehicle[n].enabled = false;
            }

        }
        if (i < 50)
        {
            myRenderer.material.color = MyColore;
            vehicle[n].enabled = true;
        }
        if (i == 100)
        {
            i = 0;
        }


    }
    public void Human(int p)
    {

        if (i >50)
        {
            myRenderer.material.color = MyColor;
            if (inRange(humans[p].transform.position.z, Locx, locy) && myRenderer.material.color == MyColor)
            {

                humans[p].enabled = true;
                humans[p].myActiveState = VehicleFollowing2.AISTATE.walk;


            }

        }
        if (i < 50)
        {
            myRenderer.material.color = MyColore;
            humans[p].enabled =false;
        }
        if (i == 100)
        {
            i = 0;
        }

    }



}
