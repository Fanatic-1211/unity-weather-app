using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVelocity : MonoBehaviour
{
    public float minVelocity = 1f; // The minimum velocity the cube can move at.
    public float maxVelocity = 10f; // The maximum velocity the cube can move at.
    public float velocityChangeAmount = 1f; // The amount the velocity changes by when the player presses a button.
    private float currentVelocity; // The current velocity of the cube.
    private Rigidbody rbVelocity; // A reference to the cube's Rigidbody component.
    public Button upVelocityButton; // A reference to the UI button that increases the velocity.
    public Button downVelocityButton; // A reference to the UI button that decreases the velocity.

    private void Start()
    {
        rbVelocity = GetComponent<Rigidbody>(); // Get the cube's Rigidbody component on Start.
        currentVelocity = minVelocity; // Set the initial velocity to the minimum velocity.

        // Add listeners to the UI buttons to call the corresponding methods
        upVelocityButton.onClick.AddListener(IncreaseVelocity);
        downVelocityButton.onClick.AddListener(DecreaseVelocity);
    }

    private void FixedUpdate()
    {
        // Move the cube based on its current velocity.
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        rbVelocity.velocity = moveDirection.normalized * currentVelocity;
    }

    private void IncreaseVelocity()
    {
        currentVelocity = Mathf.Min(currentVelocity + velocityChangeAmount, maxVelocity);
    }
    private void DecreaseVelocity()
    {
        currentVelocity = Mathf.Max(currentVelocity - velocityChangeAmount, minVelocity);
    }
}

