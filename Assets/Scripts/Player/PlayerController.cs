using System;
using MLAPI;
using MLAPI.Messaging;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private PlayerNetwork _playerNetwork;
    
    private void OnEnable()
    {
        if (_playerNetwork.IsPreformScriptLogic == false) return;
        PlayerHealth.OnHealthOver += OnHealthOver;
        MouseInput.OnLeftMouseButtonPress += OnLeftMouseButtonPress;
        MouseInput.OnLeftMouseButtonUp += OnLeftMouseButtonUp;
        MouseInput.OnMouseRotation += OnMouseRotation;
        KeyboardInput.OnHorizontalInput += OnHorizontalInput;
    }
    
    private void OnDisable()
    {
        if (_playerNetwork.IsPreformScriptLogic == false) return;
        PlayerHealth.OnHealthOver -= OnHealthOver;
        MouseInput.OnLeftMouseButtonPress -= OnLeftMouseButtonPress;
        MouseInput.OnLeftMouseButtonUp -= OnLeftMouseButtonUp;
        MouseInput.OnMouseRotation -= OnMouseRotation;
        KeyboardInput.OnHorizontalInput += OnHorizontalInput;
    }




    private void OnHealthOver()
    {
        GetComponent<PlayerSpawner>()?.Respawn();
        print("Player health is over");
    }

    private void OnLeftMouseButtonPress()
    {
        GetComponent<PlayerAttack>()?.Attack();
    }
    
    private void OnHorizontalInput(float horizontal, float vertical)
    {
        GetComponent<PlayerMovement>()?.MoveByInput(horizontal, vertical);
    }
    
    private void OnLeftMouseButtonUp()
    {
        GetComponent<PlayerAttack>()?.StopAttack();
    }
    
    private void OnMouseRotation(Vector2 mouseRotation)
    {
        GetComponent<PlayerMovement>()?.RotateByMouse(mouseRotation);
    }
}
