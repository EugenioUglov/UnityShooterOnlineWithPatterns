using MLAPI;
using UnityEngine;

public class PlayerAttack : NetworkBehaviour
{
    [SerializeField] 
    private WeaponBehavior _weapon;

    [SerializeField]
    private PlayerNetwork _playerNetwork;
    
    private bool _isAttacking = false;
    
    private MouseInput _mouseInput;

    
    private void Start()
    {
         _mouseInput = MouseInput.Instance;
    }

    private void Update()
    {
        if (_playerNetwork.IsPreformScriptLogic == false) return;
        
        CheckAttack();
    }
    
    public void Attack()
    {
        _weapon.Attack();
    }

    public void StopAttack()
    {
        _weapon.StopAttack();
    }
    
    private void CheckAttack()
    {
        if (_mouseInput.IsClickedLeftMouseButton)
        {
            _isAttacking = true;
            Attack();
        }
        else
        {
            _isAttacking = false;
            StopAttack();
            
        }
    }
}
