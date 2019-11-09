using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public ParticleSystem particle;

    public void SpawnParticle()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
    }

}
