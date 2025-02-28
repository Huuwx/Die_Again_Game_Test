using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundMoving : MonoBehaviour
{
    public Rigidbody rb;

    private bool isActive = false;
    
    [SerializeField] Vector3 posToMove;
    [SerializeField] float GroundSpeed = 30f;

    private void Awake()
    {
        isActive = false;
    }

    private void Update()
    {
        if (isActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, posToMove, GroundSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = true;
        }
    }
}
