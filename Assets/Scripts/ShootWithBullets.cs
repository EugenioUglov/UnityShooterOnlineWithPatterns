using UnityEngine;

public class ShootWithBullets : ShootBehavior 
{
    [SerializeField] 
    private GameObject _bullet;

    public ShootWithBullets(GameObject bullet)
    {
        _bullet = bullet;
    }

    public override void Shoot(float fireRate)
    {
        if (_bullet.activeSelf == false)
        {
            _bullet.SetActive(true);
        }
    }

    public override void StopShoot()
    {
        if (_bullet.activeSelf)
        {
            _bullet.SetActive(false);    
        }
    }
}
