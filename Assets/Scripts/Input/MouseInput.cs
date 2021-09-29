using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MouseInput : MonoBehaviour
{
    public static MouseInput Instance;

    public static event Action OnLeftMouseButtonPress;
    public static event Action OnLeftMouseButtonUp;
    public static event Action<Vector2> OnMouseRotation;

    private bool _isLeftMouseButtonPress = false;
    private bool _isMouseRotated = false;
    
    public Vector2 MouseRotation
    {
        get;
        private set;
    }
    
    public bool IsLeftMouseButtonPress
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
        CheckMouseRotation();
        CheckMouseClick();
    }

    private void CheckMouseRotation()
    {
        Vector2 currentMouseRotation = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
       
        if (MouseRotation != currentMouseRotation)
        {
            MouseRotation = currentMouseRotation;
            OnMouseRotation?.Invoke(MouseRotation);
        }
    }

    private void CheckMouseClick()
    {      
        if (Input.GetMouseButton(0))
        {
            IsLeftMouseButtonPress = true;
            OnLeftMouseButtonPress?.Invoke();
        }
        else
        {
            if (IsLeftMouseButtonPress)
            {
                IsLeftMouseButtonPress = false;
                OnLeftMouseButtonUp?.Invoke();
            }
        }
    }
}
