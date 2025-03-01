using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    
    private int currentLevel;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        currentLevel = 1;
    }

    private void Start()
    {
        PlayerInfor.Instance.setPlayerIQ(0);
    }

    public int getCurrentLevel()
    {
        return currentLevel;
    }

    public void setNextLevel(int plusNumber)
    {
        this.currentLevel += plusNumber;
    }
}
