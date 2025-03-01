using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance{get; private set;}
    
    [SerializeField] PlayerMovement playerMovement;
    
    public Animator animator;
    

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

    private void Start()
    {
        PlayerInfor.Instance.setIsAlive(true);
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
        PlayerInfor.Instance.setIsAlive(false);
        animator.SetTrigger("Dead");
        playerMovement.rb.useGravity = false;
        
        yield return new WaitForSeconds(1.5f);
        
        PlayerInfor.Instance.setPlayerIQ(1);
        SceneController.Instance.LoadScene("GameOverScene");
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jumping", false);
            PlayerInfor.Instance.setIsGrounded(true);
        }

        if (other.gameObject.CompareTag("Gate"))
        {
            GameManager.Instance.setNextLevel(1);
            if (GameManager.Instance.getCurrentLevel() == 3)
            {
                GameManager.Instance.setNextLevel(-2);
            }
            SceneController.Instance.LoadScene("Level" + GameManager.Instance.getCurrentLevel().ToString());
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
