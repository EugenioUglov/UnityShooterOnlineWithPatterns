using System;
using MLAPI.Messaging;
using UnityEditor.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpawner : Spawner
{
    public static PlayerSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }



    public void Respawn()
    {
        RespawnServerRpc();
    }

    
    [ServerRpc]
    private void RespawnServerRpc()
    {
        RespawnClientRpc();
    }

    [ClientRpc]
    public void RespawnClientRpc()
    {
        PerformRespawn();
    }

    
    private void PerformRespawn()
    {
        transform.position = GetRandomPosition();
    }
    
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-2, 2);
        float y = 1.65f;
        float z = Random.Range(-2, 2);

        return new Vector3(x, y, z);
    }

}
