using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
    }
    
public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Application.LoadLevel("Main");
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Application.LoadLevel("SampleScene");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Main");
        }
    }
}
