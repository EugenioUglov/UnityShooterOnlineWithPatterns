using MLAPI;
using UnityEngine;

public class PlayerAttack : NetworkBehaviour
{
    [SerializeField] 
    private WeaponBehavior _weapon;


    
    public void Attack()
    {
        _weapon.Attack();
    }

    public void StopAttack()
    {
        _weapon.StopAttack();
    }
    
}
