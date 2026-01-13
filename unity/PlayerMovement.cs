using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables for all the arbitrary numbers that movement uses. 
    // [SerializeField] allows the numbers to be changed in the inspector.

    [SerializeField] Transform orientation; // An empty object. Every object has a forward direction, 
    // so we use the forward directoin of this object to determine which way the player is facing. 
    // Then, by turning this object in the PlayerLook script, we can make sure the player's forward direction 
    // matches their camera's direction.

    [Header("Movement")]
    [SerializeField] public float moveSpeed = 6f; // The base movement speed of the player.
    [SerializeField] float airMultiplier = 0.4f; // When the player is in the air, multiply by this number to reduce their control.
    float movementMultiplier = 10f; // An arbitrary multiplier, useful if the player character is scaled up or down relative to Unity's default coordinate system.
    [SerializeField] public float walkSpeed = 4f; //How fast the player moves when walking. If you wanted to add sprinting, this would be the base speed.
    [SerializeField] float acceleration = 10f; //How fast the player accelerates to their desired speed.

    [Header("Jumping")]
    public float jumpForce = 20f; //How much force the player jumps with.
    [SerializeField] float playergravity = 20; // How strong the gravity is for the player only. Other objects still use default gravity.

    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space; //What key the player uses to jump.

    [Header("Drag")]
    [SerializeField] float groundDrag = 6f; //How much drag the player has on the ground.
    [SerializeField] float airDrag = 2f; //How much drag the player has when not on the ground.

    // Unity reads directional inputs (WASD and arrow keys) as positive and negative numbers. These variables store those.
    float strafeMovement;
    float frontbackMovement;

    [Header("Ground Detection")]
    [SerializeField] LayerMask groundMask; //We use Unity's layer system to determine whether something is the ground or not. The player shouldn't be able to jump off of projectiles or enemies (unless you want them to be able to).
    [SerializeField] float groundDistance = 2f; //How far down the script looks below the player for the ground. Change this if the player's center is far off the ground for some reason.
    public bool isGrounded { get; private set; } //An internal variable to store whether the player is on the ground.

    Vector3 moveDirection; //A vector to store the actual direction the player is moving in, as opposed to where they want to be moving.

    Rigidbody rb; //Used to store the physics component of the player.


    private void Start() // This method is called once at the start of the game.
    {
        rb = GetComponent<Rigidbody>(); // We set things up by storing the player's physics controls for later,
        rb.freezeRotation = true; // and freezing their rotation so they can't fall over.
    }

    private void Update() // This method is called once per frame.
    {
        /*
        We do all the math for movement here. We never actually move the player though.
        This is because this method is run every time a new frame is rendered.
        If the game got really laggy and started freezing up, the player's movement would break.
        */

        Physics.gravity = new Vector3(0, -playergravity, 0); // Reset the player's specific gravity
        GroundCheck(); // Check if the player is on the ground
        MyInput(); // Read input from the keyboard and store it
        ControlDrag(); // Do all the math for the player's drag
        ControlSpeed(); // Do all the math for the player's speed, now that we know their drag

        if (Input.GetKeyDown(jumpKey) && isGrounded) // Do we want to jump, and are we able to?
        {
            Jump();
        }

    }

    void MyInput()
    {
        strafeMovement = Input.GetAxisRaw("Horizontal"); //GetAxisRaw() gives us a number that is positive or negative depending on which keys are pressed.
        frontbackMovement = Input.GetAxisRaw("Vertical"); //It reads both WASD and the arrow keys at the same time, so this will work for both.

        moveDirection = orientation.forward * frontbackMovement + orientation.right * strafeMovement;
        //We make a vector that contains everything we're getting from the keyboard,
        //and then make it relative to the camera's direction by multiplying it by our
        //orientation object's forward direction.
    }

    void Jump()
    {
        //This just sets our vertical velocity to 0. If we're falling and try to jump, this makes sure we get the full force of the jump.
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        //Now we actually add force to the player to make them jump. Make sure it's pointing the right way by multiplying it by a vector that points up from the player.
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ControlSpeed()
    {
        //Lerp is a function that takes two values and smoothly transitions between them.
        //We're using it to make our speed change smoothly instead of suddenly snapping when we press a key.
        moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
    }

    void ControlDrag()
    {
        //Linear damping is how much resistance there is to movement. This just makes sure that being in the air feels more like jumping than just walking in the air.
        if (isGrounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = airDrag;
        }
    }

    private void FixedUpdate()
    {
        //FixedUpdate() is called a a specific number of times per second. It can never be affected by lag.
        //This means it's finally safe to actually move the player.
        MovePlayer();
    }

    void MovePlayer()
    {
        if (isGrounded)
        {
            //Accelerate the player towards our stored direction, with a force equal to our speed times our scale factor.
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else if (!isGrounded)//If we're in the air, the player should have less control over their movement, so we multiply their speed by a fraction.
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
        }
    }
    void GroundCheck()
    {
        RaycastHit hit;
        Vector3 dir = new Vector3(0, -1); //This is a vector that points straight down.

        //The Physics.Raycast() function shoots out an invisible line in a given direction, for a given distance,
        //and returns true if it hits anything. Our direction is the down vector, and our distance is the groundDistance variable.
        //If we hit something that we consider ground, that means it's close enough that the player is standing on it.
        //The hit variable contains information about what we hit. We don't really care about it, but Unity won't let us ignore it.
        if (Physics.Raycast(transform.position, dir, out hit, groundDistance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
