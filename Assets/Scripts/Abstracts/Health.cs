using System.Data;
using MLAPI;
using MLAPI.NetworkVariable;
using UnityEngine;

public abstract class Health : NetworkBehaviour
{
    // Synchronized variable to store health for Network.
    // private NetworkVariableInt _networkHealth = new NetworkVariableInt(100);
    protected NetworkVariableInt _networkHealth = new NetworkVariableInt(new NetworkVariableSettings{WritePermission = NetworkVariablePermission.OwnerOnly}, 100);
    
    [SerializeField] protected int _currentHealth = 100;
    
    
    private void Update()
    {
       _currentHealth = _networkHealth.Value;
    }

    public virtual void DecreaseHealth(int healthDecreaseValue)
    {
        if (healthDecreaseValue <= 0)
        {
            throw new SyntaxErrorException("Value of decreasing health must be more than 0");
        }

        if (_currentHealth <= 0)
        {
            return;
        }

        _networkHealth.Value -= healthDecreaseValue;
        _currentHealth = _networkHealth.Value;
    }
}
