using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public GameObject player;
    public float screenPercentToScroll; // Last n-percent of screen scrolls
    public float maxOffset; // max screen offset
    public float scrollRate; // screen scroll rate

    private Vector3 offset;
    private Vector3 mousePosition;

	// Use this for initialization
	void Start () {
        offset = new Vector3(0, 0, -10); //transform.position - player.transform.position;
        Debug.Log(string.Concat(offset.x.ToString(), offset.y.ToString(), offset.z.ToString()));
    }
	
	// Update is called once per frame
	void LateUpdate () {

        // Horizontal scroll check
        if ((mousePosition.x > Screen.width * (1-(screenPercentToScroll/100))) && offset.x < maxOffset)
        {
            //Scroll camera right
            offset = offset + new Vector3 (scrollRate * Time.deltaTime, 0,0);
        }
        else if ((mousePosition.x < Screen.width * (screenPercentToScroll/100)) && offset.x > -maxOffset)
        {
            //Scroll camera left
            offset = offset + new Vector3(-scrollRate * Time.deltaTime, 0, 0);
        }

        // Vertical scroll check
        if (mousePosition.y > Screen.height * (1 - (screenPercentToScroll / 100)) && offset.y < maxOffset)
        {
            //Scroll camera up
            offset = offset + new Vector3(0, scrollRate*Time.deltaTime, 0);
        }
        else if (mousePosition.y < Screen.height * (screenPercentToScroll / 100) && offset.y > -maxOffset)
        {
            //Scroll camera down
            offset = offset + new Vector3(0, -scrollRate * Time.deltaTime, 0);
        }

        transform.position = player.transform.position + offset;
        mousePosition = Input.mousePosition;
    }
}
