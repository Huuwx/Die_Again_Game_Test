using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerInfor.Instance.setIsAlive(false);
            PlayerController.Instance.animator.SetBool("Running", false);
            GameManager.Instance.setNextLevel(1);
            if (GameManager.Instance.getCurrentLevel() == 3)
            {
                GameManager.Instance.setNextLevel(-2);
            }
            StartCoroutine(SceneController.Instance.LoadScene("Level" + GameManager.Instance.getCurrentLevel().ToString()));
        }
    }
}
