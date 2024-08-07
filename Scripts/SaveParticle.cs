using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveParticle : MonoBehaviour
{
    
    [SerializeField] private ParticleSystem system;
    public static ParticleSystem particlueInstace;
    private void Awake()
    {
        if (particlueInstace == null)
        {
            particlueInstace = Instantiate(system, transform.position, transform.rotation);
            DontDestroyOnLoad(particlueInstace);
        }
       
    }

    
}
