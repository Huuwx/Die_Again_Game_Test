using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void RetryBtn()
    {
        SceneController.Instance.LoadScene("Level" + GameManager.Instance.currentLevel.ToString());
    }

    public void HomeBtn()
    {
        SceneController.Instance.LoadScene("HomeScene");
    }

    public void StartBtn()
    {
        SceneController.Instance.LoadScene("Level" + GameManager.Instance.currentLevel.ToString());
    }
}
