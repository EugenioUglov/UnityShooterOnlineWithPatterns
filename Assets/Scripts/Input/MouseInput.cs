using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public static MouseInput Instance;


    public Vector2 MouseRotation
    {
        get;
        private set;
    }
    
    public bool IsClickedLeftMouseButton
    {
        get;
        private set;
    }

    public int RandomNumber
    {
        get
        {
            return Random.Range(0, 1000);
        }
    }


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        MouseRotation = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        IsClickedLeftMouseButton = Input.GetMouseButton(0);
    }
}
