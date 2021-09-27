using MLAPI;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField]
    private Camera _camera;
    
    private bool _isPreformScriptLogic = true;

    public bool IsPreformScriptLogic => _isPreformScriptLogic;

    protected void Start()
    {
        if (NetworkData.IsOnlineGame)
        {
            NetworkData.IsLocalPlayer = IsLocalPlayer;
            _isPreformScriptLogic = IsLocalPlayer;
            
            if (_isPreformScriptLogic == false)
            {
                Destroy(this);
                _camera.GetComponent<AudioListener>().enabled = false;
                _camera.GetComponent<Camera>().enabled = false;
            }
        }
    }
}
