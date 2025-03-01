using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfor : MonoBehaviour
{
    public static  PlayerInfor Instance{get; private set;}
    
    [Header("Player Stats")]
    private int playerIQ = 0;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float jumpForce = 4f;
    
    [Header("Player State")]
    private bool isGrounded;
    private bool isAlive;

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
    
    public bool getIsGrounded()
    {
        return isGrounded;
    }
    
    public bool getIsAlive()
    {
        return isAlive;
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }

    public float getJumpForce()
    {  
        return jumpForce;
    }
    public int getPlayerIQ()
    {
        return playerIQ;
    }

    public void setPlayerIQ(int subtractNumber)
    {
        this.playerIQ -= subtractNumber;
    }
    public void setIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }
    
    public void setIsAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }
}
