using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterJump : MonoBehaviour
{
    public InputActionProperty jumpButton;
    public GameObject platformForClimbing;
    public float jumpHeight = 2.0f;         // Height of the jump
    public float gravity = -9.81f;          // Gravity value
    private BoxCollider platformForClimbingCollider;
    private bool isGrounded;
    private bool canJump;
    private float verticalVelocity = 0;
    private bool applyGravity = true;
    private CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        platformForClimbingCollider = platformForClimbing.GetComponent<BoxCollider>();
    }

    public void GrabHoop()
    {
        StopJumpAndGravity();
        platformForClimbingCollider.enabled = true;
    }

    public void GrabRelease()
    {
        platformForClimbingCollider.enabled = false;
        characterController.Move(new Vector3(0, 0.01f, 0));
    }


    private void Jump()
    {
        verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        applyGravity = true;
        canJump = false;
    }

    private void StopJumpAndGravity()
    {
        // Stop jump and temporarily disable gravity
        verticalVelocity = 0;
        applyGravity = false;
        characterController.Move(Vector3.zero);
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            if (applyGravity)
            {
                // Reset when grounded
                if (verticalVelocity < 0)
                    verticalVelocity = -2f;
            }

            canJump = true;
        }

        if (canJump) {
            // While grounded, respond to jump button
            if (jumpButton.action.triggered)
                Jump();
        }

        // Apply gravity if enabled
        if (applyGravity) {
            verticalVelocity += gravity * Time.deltaTime;
        }

        // Move the character based on vertical velocity
        if (applyGravity)
        {
            characterController.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
        }
    }
}
