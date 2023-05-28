using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoderAnimations : MonoBehaviour
{
    [SerializeField] GameObject _runParticle;

    public void SpawnParticle()
    {
        Instantiate(_runParticle, transform.position, Quaternion.identity);
    }
}
