using UnityEngine;

public class RotateOnDrag : MonoBehaviour
{
    public float rotationSpeed = 5.0f; // Adjust this to control how fast the rotation happens.

    private bool isDragging = false;
    private float startMouseX;
    private float startRotationY;

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            startMouseX = Input.mousePosition.x;
            startRotationY = transform.eulerAngles.y;
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // If dragging, rotate the object based on mouse movement
        if (isDragging)
        {
            float mouseDeltaX = Input.mousePosition.x - startMouseX;
            float newRotationY = startRotationY + mouseDeltaX * rotationSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0, newRotationY, 0), 0.125f);
        }
    }
}
