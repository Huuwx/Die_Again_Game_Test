using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void HomeBtn()
    {
        SoundController.Instance.PlaySfx(SoundController.Instance.GetClickSfx());
        StartCoroutine(SceneController.Instance.LoadScene("HomeScene"));
    }

    public void LoadLevelBtn()
    {
        SoundController.Instance.PlaySfx(SoundController.Instance.GetClickSfx());
        StartCoroutine(SceneController.Instance.LoadScene("Level" + GameManager.Instance.getCurrentLevel().ToString()));
    }
}