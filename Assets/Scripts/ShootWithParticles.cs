using System;
using UnityEngine;

public class ShootWithParticles : ShootBehavior
{
    [SerializeField] 
    private ParticleSystem _bulletParticleSystem;
    
    private ParticleSystem.EmissionModule _particleEmissionModule;
    // private bool _isShooting = false;     
    
    private void Awake()
    {
        _particleEmissionModule = _bulletParticleSystem.emission;
        _particleEmissionModule.rateOverTime = 0;
    }

    public override void Shoot(float fireRate)
    {
        _particleEmissionModule.rateOverTime = fireRate;
    }

    public override void StopShoot()
    {
        _particleEmissionModule.rateOverTime = 0f;
    }

}
