using System;
using MLAPI;
using UnityEngine;

public class Game : NetworkBehaviour
{    
    [SerializeField] 
    private bool _isOnlineGame = true;
    
    [Header("References")]
    
    [SerializeField] 
    private OnlineGame _onlineGame;
    
    [SerializeField] 
    private OfflineGame _offlineGame;
    
    private void Awake()
    {
        NetworkData.IsOnlineGame = _isOnlineGame;
        
        if (_isOnlineGame)
        {
            _onlineGame.StartOnlineGame();
        }
        else
        {
            _offlineGame.StartOfflineGame();
        }
    }

    public void OnStart()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
