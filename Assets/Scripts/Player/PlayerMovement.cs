using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    
    [SerializeField] float rotateSpeed = 720f;
    [SerializeField] Vector2 moveDir = Vector2.zero;
    
    [SerializeField] GameObject player;

    private PlayerInput playerInput;
    private InputAction move;
    private InputAction jump;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInfor.Instance.getIsAlive())
        {
            moveDir = move.ReadValue<Vector2>();
            moveDir = moveDir.normalized;

            if (moveDir != Vector2.zero)
            {
                PlayerController.Instance.animator.SetBool("Running", true);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.y), Vector3.up);
                player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
            }
            else
            {
                PlayerController.Instance.animator.SetBool("Running", false);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDir.x * PlayerInfor.Instance.getMoveSpeed(), rb.velocity.y, moveDir.y * PlayerInfor.Instance.getMoveSpeed());
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
        if (PlayerInfor.Instance.getIsGrounded() && PlayerInfor.Instance.getIsAlive())
        {
            SoundController.Instance.PlaySfx(SoundController.Instance.GetJumpSfx());
            rb.velocity = new Vector3(rb.velocity.x, PlayerInfor.Instance.getJumpForce(), rb.velocity.z);
        }
    }
}
