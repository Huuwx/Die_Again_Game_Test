using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    
    public float moveSpeed = 2f;
    public float jumpForce = 4f;
    public float rotateSpeed = 720f;
    public Vector2 moveDir = Vector2.zero;
    
    public GameObject player;

    private PlayerInput playerInput;

    private InputAction move;
    private InputAction jump;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = move.ReadValue<Vector2>();
        moveDir = moveDir.normalized;

        if (moveDir != Vector2.zero)
        {
            PlayerController.Instance.animator.SetBool("Running", true);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.y),  Vector3.up);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
        else
        {
            PlayerController.Instance.animator.SetBool("Running", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDir.x * moveSpeed, rb.velocity.y, moveDir.y * moveSpeed);
    }

    private void OnEnable()
    {
        move = playerInput.Player.Move;
        move.Enable();
        
        jump = playerInput.Player.Jump;
        jump.Enable();
        jump.performed += ctx => Jump();
    }

    private void OnDisable()
    {
        move.Disable();
        
        jump.Disable();
    }

    private void Jump()
    {
        if (PlayerController.Instance.isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
}
