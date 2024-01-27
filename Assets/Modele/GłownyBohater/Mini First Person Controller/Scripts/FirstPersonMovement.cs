using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    private Animator animator;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Pobierz wejście gracza
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool isMovingForward = verticalInput > 0;
        bool isMovingBackward = verticalInput < 0;
        bool isMovingLeft = horizontalInput < 0;
        bool isMovingRight = horizontalInput > 0;

        bool isMovingForwardRight = isMovingForward && isMovingRight;
        bool isMovingForwardLeft = isMovingForward && isMovingLeft;
        bool isMovingBackwardRight = isMovingBackward && isMovingRight;
        bool isMovingBackwardLeft = isMovingBackward && isMovingLeft;

        // Ustaw parametry boolowskie w kontrolerze animacji
        animator.SetBool("IsMovingForward", isMovingForward);
        animator.SetBool("IsMovingBackward", isMovingBackward);
        animator.SetBool("IsMovingLeft", isMovingLeft);
        animator.SetBool("IsMovingRight", isMovingRight);
        animator.SetBool("IsMovingForwardRight", isMovingForwardRight);
        animator.SetBool("IsMovingForwardLeft", isMovingForwardLeft);
        animator.SetBool("IsMovingBackwardRight", isMovingBackwardRight);
        animator.SetBool("IsMovingBackwardLeft", isMovingBackwardLeft);

        if (isMovingForwardRight)
        {
            animator.SetBool("IsMovingForwardLeft", false);
            animator.SetBool("IsMovingBackwardRight", false);
            animator.SetBool("IsMovingBackwardLeft", false);
        }
        else if (isMovingForwardLeft)
        {
            animator.SetBool("IsMovingForwardRight", false);
            animator.SetBool("IsMovingBackwardRight", false);
            animator.SetBool("IsMovingBackwardLeft", false);
        }
        else if (isMovingBackwardRight)
        {
            animator.SetBool("IsMovingForwardRight", false);
            animator.SetBool("IsMovingForwardLeft", false);
            animator.SetBool("IsMovingBackwardLeft", false);
        }
        else if (isMovingBackwardLeft)
        {
            animator.SetBool("IsMovingForwardRight", false);
            animator.SetBool("IsMovingForwardLeft", false);
            animator.SetBool("IsMovingBackwardRight", false);
        }

        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);

        ///animator.SetBool("IsRunning", IsRunning);
    }
}