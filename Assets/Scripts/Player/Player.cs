using MLAPI;
using MLAPI.Messaging;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private void Start()
    {
        PlayerHealth.OnHealthOver += OnHealthOver;
    }
    
    private void OnDestroy()
    {
        PlayerHealth.OnHealthOver -= OnHealthOver;
    }

    
    private void OnHealthOver()
    {
        GetComponent<PlayerSpawner>().Respawn();
        print("Health is over");
    }
}
