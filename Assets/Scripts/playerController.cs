using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public int playerSpeed;
    public float shootDebounce;
    public float shootDistance;

    private Vector3 moveXY;
    private Vector2 mousePos;
    private Rigidbody2D rb2d;
    private Vector3 mousePosition;
    private Vector3 lookVector;
    private float angle; // Rotation angle of player
    private float lastShot = 0;
    private float trailDebounce = 0.02f;
    private Vector3 endPoint;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }


    // Update is called once per frame
    void Update()
    {
        lookVector = mousePosition - transform.position;
        Player_Move();

        //Check for mouse button 0 keypress
        if (Input.GetKeyDown(KeyCode.Mouse0) && (Time.fixedTime - lastShot) >= shootDebounce) //MB1 and debounce time is passed
        {
            Shoot();
        }
        
    }


    void Player_Move()
    {
        //Player Movement
        moveXY = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb2d.velocity = (moveXY * playerSpeed);
        rb2d.angularVelocity = 0;

        //Player Rotation
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f));
        angle = Mathf.Atan2(lookVector.y, lookVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot()
    {
        lastShot = Time.fixedTime; //
        //print(LayerMask.NameToLayer("Player"));
        int layermask1 = 1 << LayerMask.NameToLayer("Player"); //Binary bit-shift
        int layermask2 = 1 << LayerMask.NameToLayer("Triggers");
        int finalmask = layermask1 | layermask2; // Combine layerMasks
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, shootDistance, ~(finalmask)); // raycast
        if (hit.collider != null)
        {
            // HIT!
            print(hit.point);
            endPoint = hit.point; // endpoint at collision
        }
        else
        {
            // MISS!
            endPoint = transform.position + shootDistance * transform.right; // endpoint at max dist
        }
        Vector3 startPoint = (transform.position + 1.2f * transform.right);
        Debug.DrawRay(startPoint, (endPoint - startPoint), Color.yellow, trailDebounce); // draw preview

    }

}
