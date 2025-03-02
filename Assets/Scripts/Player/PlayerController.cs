using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] PlayerMovement playerMovement;

    public Animator animator;

    public bool isActive;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        isActive = true;
    }

    private void Start()
    {
        PlayerInfor.Instance.setIsAlive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -0.5)
        {
            if (isActive)
            {
                StartCoroutine(Dead());
                isActive = false;
            }
        }
    }

    IEnumerator Dead()
    {
        SoundController.Instance.PlaySfx(SoundController.Instance.GetDeadSfx());
        PlayerInfor.Instance.setPlayerIQ(1);
        PlayerInfor.Instance.setIsAlive(false);
        animator.SetTrigger("Dead");
        playerMovement.rb.useGravity = false;

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(SceneController.Instance.LoadScene(("GameOverScene")));
        SoundController.Instance.PlaySfx(SoundController.Instance.GetGameOverSfx());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jumping", false);
            PlayerInfor.Instance.setIsGrounded(true);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jumping", false);
            PlayerInfor.Instance.setIsGrounded(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jumping", true);
            PlayerInfor.Instance.setIsGrounded(false);
        }
    }
}