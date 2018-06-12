using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public int playerSpeed = 10;

    private Vector3 moveXY;
    private Vector2 mousePos;
    private Rigidbody2D rb2d;
    private Vector3 mousePosition;
    private Vector3 lookVector;
    private float angle; // Rotation angle of player

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }


    // Update is called once per frame
    void Update()
    {
        Player_Move();
    }


    void Player_Move()
    {

        //Player Movement
        moveXY = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        mousePos = Input.mousePosition;
        rb2d.AddForce(moveXY * playerSpeed);

        //Player Rotation
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f));
        lookVector = mousePosition - transform.position;
        angle = Mathf.Atan2(lookVector.y, lookVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

}
