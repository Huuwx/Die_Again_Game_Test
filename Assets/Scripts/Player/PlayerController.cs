using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance{get; private set;}
    
    public PlayerMovement playerMovement;
    
    public Animator animator;
    
    public bool isGrounded;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -0.5)
        {
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        animator.SetTrigger("Dead");
        playerMovement.rb.useGravity = false;
        
        yield return new WaitForSeconds(1.5f);
        
        SceneController.Instance.LoadScene("GameOverScene");
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jumping", false);
            isGrounded = true;
        }

        if (other.gameObject.CompareTag("Gate"))
        {
            SceneManager.LoadScene("Level1");
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jumping", false);
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jumping", true);
            isGrounded = false;
        }
    }
}
