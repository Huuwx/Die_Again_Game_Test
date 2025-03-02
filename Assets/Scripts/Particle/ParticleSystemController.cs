using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;

    public void PlayMovementParticle()
    {
        movementParticle.Play();
    }
}
