using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 10f;
    public float axisForce = 250f;
    public float speed = 1;
    public float sideSensitivity = 100;
    public float pv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = 1;

        Vector3 velocity = new Vector3(xMov, 0, zMov) * speed;

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        /*forward Force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if ( Input.GetKey("d"))
        {
            rb.AddForce(axisForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("q"))
        {
            rb.AddForce(-axisForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }*/

        if(rb.position.y < -2f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
