using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverController : MonoBehaviour
{
    [SerializeField] Text  playerIQText;
    [SerializeField] Text LevelText;

    private void Start()
    {
        playerIQText.text = PlayerInfor.Instance.getPlayerIQ().ToString() + " IQ";
        LevelText.text = "Level" + GameManager.Instance.getCurrentLevel().ToString();
    }
}
