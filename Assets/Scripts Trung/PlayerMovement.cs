using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6.0f;

    public float groundDrag = 6.0f;

    [Header("Ground Check")]
    public Transform playerObj;
    public CapsuleCollider playerCollider;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    public float jumpForce = 5.0f;
    public float jumpCooldown = 0.25f;
    public float airMultiplier = 0.5f;
    
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Double jump
    public int doubleJumpCharge = 1;

    bool canDoubleJump = false;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerCollider.height * playerObj.localScale.y * 0.5f + 0.25f, whatIsGround);
        MyInput();
        SpeedControl();
        // Debug.Log(grounded);
        // handle drag
        if (grounded)
        {
            canDoubleJump = true;
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0.0f;
        }
    }

    private void FixedUpdate()
    {
        if (!canMove)
            return;
        MovePlayer();
    }

    public void ResetDoubleJump()
    {
        doubleJumpCharge = 2;
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(jumpKey))
        {
            Debug.Log(grounded);
        }
        if (Input.GetKeyDown(jumpKey) && grounded)
        {
            Jump();
        } else if (Input.GetKeyDown(jumpKey) && doubleJumpCharge > 0 && canDoubleJump)
        {
            canDoubleJump = false;
            Jump();
            doubleJumpCharge--;
        }
    }

    private void MovePlayer()
    {
        moveDirection = transform.forward * -horizontalInput + transform.right * verticalInput ;
        
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            flatVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(flatVel.x, rb.velocity.y, flatVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
