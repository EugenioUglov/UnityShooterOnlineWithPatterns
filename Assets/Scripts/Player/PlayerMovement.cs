using MLAPI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] 
    private float _speed = 2f;

    [SerializeField] 
    private float _lookSensitivity = 3f;
    
    [SerializeField]
    protected Camera _camera;
    
    [SerializeField]
    private PlayerNetwork _playerNetwork;

    private KeyboardInput _keyboardInput;
    private MouseInput _mouseInput;
    
    
    private Rigidbody _rigidbody;
    private float _pitch = 0;
    private Transform _cameraTransform;

    private void Start()
    {
        _keyboardInput = KeyboardInput.Instance;
        _mouseInput = MouseInput.Instance;
        
        _rigidbody = GetComponent<Rigidbody>();
        _cameraTransform = _camera.transform;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        if (_playerNetwork.IsPreformScriptLogic == false) return;

        CheckMove();
        CheckRotate();
    }
    
    private void CheckMove()
    {
        MoveByInput();
    }

    private void CheckRotate()
    {
        RotateByMouse();
    }
        
        
    private void MoveByInput()
    {       
        // Move by X axis.
        Vector3 horizontal = transform.right * _keyboardInput.Horizontal;
        // Move by Z axis.
        Vector3 vertical = transform.forward * _keyboardInput.Vertical;
        Vector3 velocity = (horizontal + vertical).normalized * _speed;

        
        PerformMovement(velocity);
    }
    
    private void PerformMovement(Vector3 moveVector)
    {       
        if (moveVector != Vector3.zero)
        {
            _rigidbody.MovePosition(_rigidbody.position + moveVector * Time.deltaTime);
        }
    }
    
    private void RotateByMouse()
    {
        Vector3 rotation = new Vector3(0, _mouseInput.MouseRotation.x, 0) * _lookSensitivity;
        
        _pitch -= _mouseInput.MouseRotation.y * _lookSensitivity;
        _pitch = Mathf.Clamp(_pitch, -45f, 45f);
        Vector3 cameraRotation = new Vector3(_pitch, 0, 0);
        
        PerformRotation(rotation, cameraRotation);
    }
    
    private void PerformRotation(Vector3 rotation, Vector3 cameraRotation)
    {
        //_rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(rotation));
        //_camera.transform.Rotate(cameraRotation);
        transform.Rotate(rotation);
        _cameraTransform.localRotation = Quaternion.Euler(cameraRotation);
    }
}
