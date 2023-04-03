using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 20;
    public Rigidbody rb;
    float horizontalSpeed;
    float verticalSpeed;

    public Color leftColor = Color.blue;
    public Color rightColor = Color.red;
    public Color upColor = Color.green;
    public Color downColor = Color.yellow;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //WASD input
        horizontalSpeed = Input.GetAxis("Horizontal");
        verticalSpeed = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //movement vector to the Rigidbody component.
        rb.AddForce(Vector3.up * verticalSpeed * movementSpeed);
        rb.AddForce(Vector3.right * horizontalSpeed * movementSpeed);

        // Setting the colour of the cube based on the direction it's moving.
        if (horizontalSpeed < 0f)
        {
            GetComponent<Renderer>().material.color = leftColor;
        }
        else if (horizontalSpeed > 0f)
        {
            GetComponent<Renderer>().material.color = rightColor;
        }
        else if (verticalSpeed < 0f)
        {
            GetComponent<Renderer>().material.color = upColor;
        }
        else if (verticalSpeed > 0f)
        {
            GetComponent<Renderer>().material.color = downColor;
        }

    }

}
