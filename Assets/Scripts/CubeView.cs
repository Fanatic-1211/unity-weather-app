using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeView : MonoBehaviour
{
    private Camera mainCamera;
    private Renderer cubeRenderer; 

    private void Start()
    {
        mainCamera = Camera.main;
        cubeRenderer = GetComponent<Renderer>(); 
    }

    private void LateUpdate()
    {
        // Get the position of the cube in screen coordinates.
        Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);

        //Contain the cube to the opposite edge of the screen if it goes off the edge.
        if (screenPos.x < 0f)
        {
            screenPos.x = mainCamera.pixelWidth;
        }
        else if (screenPos.x > mainCamera.pixelWidth)
        {
            screenPos.x = 0f;
        }
        if (screenPos.y < 0f)
        {
            screenPos.y = mainCamera.pixelHeight;
        }
        else if (screenPos.y > mainCamera.pixelHeight)
        {
            screenPos.y = 0f;
        }

        //Set the new position of the cube in world coordinates.
        transform.position = mainCamera.ScreenToWorldPoint(screenPos);

        ViewCube();
    }

    private void ViewCube()
    {
        //is it visible to the camera?
        if (cubeRenderer.isVisible)
        {
            GetComponent<Collider>().enabled = true;
        }
        else
        {
            GetComponent<Collider>().enabled = false;
        }
    }
}

