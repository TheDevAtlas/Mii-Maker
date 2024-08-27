using UnityEngine;

public class RotateMii : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of the rotation
    public float mouseRotationSpeed = 1000f;
    public float returnSpeed = 50f;    // Speed at which the model returns to default rotation
    public float returnDelay = 5f;     // Time before the model starts returning to default rotation

    private bool isRotating = false;   // Flag to check if the player is rotating
    private float lastInputTime = 0f;  // Time of the last user input

    void Update()
    {
        bool inputReceived = false;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch is on the right side of the screen
            if (touch.position.x > Screen.width / 2)
            {
                // Check if the touch is moving (dragging)
                if (touch.phase == TouchPhase.Moved)
                {
                    inputReceived = true;
                    float touchDeltaX = touch.deltaPosition.x;
                    transform.Rotate(Vector3.up, -touchDeltaX * rotationSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            // Mouse input handling
            if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2)
            {
                if (Input.GetAxis("Mouse X") != 0)
                {
                    inputReceived = true;
                    float mouseX = Input.GetAxis("Mouse X");
                    transform.Rotate(Vector3.up, -mouseX * mouseRotationSpeed * Time.deltaTime);
                }
            }
        }

        if (inputReceived)
        {
            isRotating = true;
            lastInputTime = Time.time;
        }
        else
        {
            if (Time.time - lastInputTime > returnDelay)
            {
                isRotating = false;
                RotateBackToDefault();
            }
        }
    }

    private void RotateBackToDefault()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, returnSpeed * Time.deltaTime);
    }
}
