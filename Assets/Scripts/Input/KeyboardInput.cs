using System;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public static KeyboardInput Instance;
    public static Action<float, float> OnHorizontalInput; 

    private float _horizontalInput;
    private float _verticalInput;
        
    public float Horizontal
    {
        get;
        private set;
    }
    
    public float Vertical
    {
        get;
        private set;
    }

    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        
        OnHorizontalInput?.Invoke(Horizontal, Vertical);
    }
}
