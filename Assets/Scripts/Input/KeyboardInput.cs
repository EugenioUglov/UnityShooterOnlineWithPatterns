using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public static KeyboardInput Instance;

    
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
    }
}
