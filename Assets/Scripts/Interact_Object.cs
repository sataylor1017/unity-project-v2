using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Object : MonoBehaviour {

    private bool opened = false;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void OnTriggerStay2D()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Chest opened!");
            opened = true;
            
        }
            
    }

    void OnTriggerExit()
    {
        if (opened == true)
        {
            opened = false;

        }

    }

}
