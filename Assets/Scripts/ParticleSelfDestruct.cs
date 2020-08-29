using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem particle = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule thisPart = particle.main;
        Destroy(gameObject, thisPart.duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
