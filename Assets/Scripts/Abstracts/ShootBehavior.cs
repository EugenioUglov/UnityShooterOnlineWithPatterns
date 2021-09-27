using UnityEngine;

public abstract class ShootBehavior : MonoBehaviour
{
    public abstract void Shoot(float fireRate);
    public abstract void StopShoot();
}
