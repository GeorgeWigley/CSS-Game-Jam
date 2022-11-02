using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float strafeSpeed = 1;
    [SerializeField] private float linearDrag = 1;
    [Space, SerializeField] private float footHeight = 0.95f;
    [SerializeField] private float checkDistance = 0.1f;
    [SerializeField] private float maxVelocityJumpThreshold = 5;
    [SerializeField] private float jumpSpeed = 10;
    [SerializeField] private LayerMask jumpMask;
    [Space]
    [SerializeField] private Animator animator;
    [SerializeField] private float moveVelocityThreshold = 10;

    [SerializeField] private float rotationSpeed = 1.0f;
    private Vector3 forward;
    private Rigidbody rb;

    private bool jumpPressed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //forward = transform.forward;
    }

    private void Update()
    {
        jumpPressed = jumpPressed | Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        bool isGrounded = Physics.Raycast(transform.position + Vector3.down * footHeight, Vector3.down, 
            checkDistance, jumpMask);
        Vector3 forwardDirection = cam.forward;
        forwardDirection.y = 0;
        forwardDirection.Normalize();

        Vector3 horizontalDirection = Vector3.Cross(Vector3.up, forwardDirection);
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        horizontalDirection *= horizontalInput;
        float verticalInput = Input.GetAxisRaw("Vertical");
        forwardDirection *= verticalInput;

        Vector3 jumpVelocity = Vector3.zero;
        if (jumpPressed)
        {
            animator.SetTrigger("jump");
            jumpPressed = false;
            if (rb.velocity.y <= maxVelocityJumpThreshold && isGrounded)
            {
                jumpVelocity = Vector3.up * jumpSpeed;
            }
        }

        float airMultiplier = isGrounded ? 1 : 0.5f;
        
        rb.AddForce((forwardDirection * (airMultiplier * movementSpeed) + horizontalDirection * (strafeSpeed * airMultiplier)) * Time.deltaTime + jumpVelocity);
        Vector3 velo = rb.velocity;
        velo.y = 0;
        velo = Vector3.Lerp(velo, Vector3.zero, Time.deltaTime * linearDrag);
        animator.SetBool("moving", velo.sqrMagnitude > moveVelocityThreshold);
        velo.y = rb.velocity.y;
        Vector3 forward = transform.forward;
        float angle = Vector3.SignedAngle(forward, velo, Vector3.up);
        
        
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime * angle) );
        // if (angle < 170)
        // {
        //     forward.y = 0;
        //     forward = Vector3.Lerp(forward, velo, Time.deltaTime * rotationSpeed);
        //     forward.y = transform.forward.y;
        //     transform.forward = forward;
        // }
        // else
        // {
        //     transform.Rotate(Vector3.up * (horizontalInput * rotationSpeed * Time.deltaTime));
        // }

        rb.velocity = velo;
    }

}
