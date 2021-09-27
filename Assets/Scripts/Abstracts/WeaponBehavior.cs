using System;
using MLAPI;
using UnityEngine;


public abstract class WeaponBehavior : NetworkBehaviour
{
    public abstract void Attack();
    public abstract void StopAttack();
}
