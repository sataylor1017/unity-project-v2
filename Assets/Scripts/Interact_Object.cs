using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Object : MonoBehaviour {

    public Sprite closedSprite;
    public Sprite openSprite;

    private bool opened = false;
    private SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void OnTriggerStay2D()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Chest opened!");
            opened = true;
            spriteRenderer.sprite = openSprite;
        }
            
    }

    void OnTriggerExit2D()
    {
        Debug.Log("exit");
        if (opened == true)
        {
            opened = false;
            spriteRenderer.sprite = closedSprite;
        }

    }

}
