using UnityEngine;
using MLAPI;

public class NetworkMenu : NetworkBehaviour
{
    [Header("References")]
    
    [SerializeField] 
    private GameObject _menuPanel;
    
    [SerializeField] 
    private GameObject _sceneCamera;

    private string _passwordToEnter = "";
    
    public void Host()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.StartHost(GetRandomPosition(), Quaternion.identity);
        OnConnection();
    }

    private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callback)
    {
        bool isApprove = System.Text.Encoding.ASCII.GetString(connectionData) == _passwordToEnter;
        callback(true, null, isApprove, GetRandomPosition(), Quaternion.identity);
    }

    public void Join()
    {
        NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes(_passwordToEnter);
        NetworkManager.Singleton.StartClient();
        OnConnection();
    }

    void OnConnection()
    {
        _menuPanel.SetActive(false);
        _sceneCamera.SetActive(false);
        
        //print(IsLocalPlayer);
        return;
        
        if (NetworkData.IsOnlineGame)
        {
            NetworkData.IsLocalPlayer = IsLocalPlayer;
        }
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-2, 2);
        float y = 1.65f;
        float z = Random.Range(-2, 2);

        return new Vector3(x, y, z);
    }
}
