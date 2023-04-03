using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 20;
    public Rigidbody rb;
    float moveHorizontal;
    float moveVertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //WASD input.
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        

        //movement vector to the Rigidbody component.
        rb.AddForce(Vector3.up * moveVertical * movementSpeed);
        rb.AddForce(Vector3.right * moveHorizontal * movementSpeed);

    }

}
