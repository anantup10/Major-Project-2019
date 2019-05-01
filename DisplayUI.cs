using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour
{
   
    public Text myText;
    public int i=0;
    
    // Start is called before the first frame update
    void Start()
    {
        myText = GameObject.Find("Text").GetComponent<Text>();
       


    }

    // Update is called once per frame
    void Update()
    {
        Test();
        if (Input.GetKeyDown(KeyCode.E))
        {
            i += 1;
        }
        

    }

    void Test()
    {
       
        if (i % 2 == 1)
        {
            myText.enabled = true;
        }
        else if(i%2 == 0)
        {
            myText.enabled = false;
        }
    }
   
    
}
