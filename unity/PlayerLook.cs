using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Variables for all the arbitrary values that the camera uses. 
    // [SerializeField] allows the values to be changed in the inspector.
    [Header("References")]

    [SerializeField] private float sensX = 100f; //These two values determine the sensitivity of the mouse on the vertical and horizontal axes.
    [SerializeField] private float sensY = 100f;

    // A Transform is an object that stores position, rotation, and scale. This one is the game's camera.
    // The script won't assign this a value, so we need to tell it what the camera is manually in the inspector.
    // This is because a game can have multiple cameras, and only we know which one is the one we want to use.
    [SerializeField] Transform cam = null;

    // Another Transform, this time of an empty object. We store rotation data from the camera in here.
    // Then, the movement script, which can also see this object, reads that data to figure out which way we're facing.
    [SerializeField] Transform orientation = null;
    float mouseX; // The pixel coordinates of the mouse on the screen.
    float mouseY;

    float multiplier = 0.01f; // This is a multiplier that we can use to adjust the sensitivity of the mouse in both directions.

    float xRotation; // These are used to store the actual desired rotation of the camera, when we calculate that.
    float yRotation;
    private void Start() // This method is called once at the start of the game.
    {
        Cursor.lockState = CursorLockMode.Locked; // CursorLockMode determines whether the cursor can leave the game window.
        Cursor.visible = false; // We don't want to see the cursor moving around the screen when we turn the camera.
    }

    private void Update() // This method is called once per frame.
    {
        mouseX = Input.GetAxisRaw("Mouse X"); // GetAxisRaw can return which way the mouse is moving and how fast as a positive or negative number.
        mouseY = Input.GetAxisRaw("Mouse Y");
         
        yRotation += mouseX * sensX * multiplier; // Calculate the desired rotation from mouse movement, sensitivity, and the final multiplier.
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the vertical rotation so the camera can't flip upside down.

        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0); // Update our empty object to send data to movement.
        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // Set the rotation of the camera to what we calculated.

        
    }
}
