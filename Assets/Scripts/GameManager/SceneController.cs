using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance{ get; private set; }

    [SerializeField] private GameObject transaction;
    [SerializeField] Animator transitionAnimator;

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

    public IEnumerator LoadScene(string scene)
    {
        transaction.SetActive(true);
        transitionAnimator.SetTrigger("End");
        
        yield return new WaitForSecondsRealtime(0.7f);
        
        SceneManager.LoadScene(scene);
        
        transitionAnimator.SetTrigger("Start");
    }
}
