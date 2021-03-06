using MLAPI.Messaging;
using UnityEngine;

public class AutomaticPistol : Gun
{
    
    private void Awake()
    {
        if (_shootBehavior == null)
        {
            _shootBehavior = GetComponent<ShootBehavior>();
        }

        _muzzleTransform = _muzzle.transform;
    }

    
    public override void Attack()
    {
        AttackServerRpc();
    }
    
    public override void StopAttack()
    {
        StopAttackServerRpc();
    }


    private void TryGiveDamage()
    {
        if (Physics.Raycast(_muzzleTransform.position, _muzzleTransform.forward, out RaycastHit hit, 200f))
        {
            Health hitHealth = hit.transform.GetComponent<Health>();
            
            if (hitHealth != null)
            {
                hitHealth.DecreaseHealth(1);
            }
        }
    }




    [ServerRpc]
    public void AttackServerRpc()
    {
        TryGiveDamage();
        
        AttackClientRpc();
    }
    
    [ServerRpc]
    public void StopAttackServerRpc()
    {
        StopAttackClientRpc();
    }
    
    
    [ClientRpc]
    private void AttackClientRpc()
    {
        _shootBehavior.Shoot(_fireRate);
    }
    
    [ClientRpc]
    private void StopAttackClientRpc()
    {
        _shootBehavior.StopShoot();
    }
}
