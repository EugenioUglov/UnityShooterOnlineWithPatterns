using UnityEngine;

public abstract class Gun : WeaponBehavior
{
    [SerializeField] 
    protected float _fireRate = 10;

    [SerializeField] 
    protected float _bulletDamage = 10;

    [SerializeField] 
    protected GameObject _muzzle;
    
    [SerializeField] 
    protected ShootBehavior _shootBehavior;

    protected Transform _muzzleTransform;
    

    public abstract override void Attack();
    public abstract override void StopAttack();
}
