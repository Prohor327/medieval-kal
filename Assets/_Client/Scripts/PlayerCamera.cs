using UnityEngine;

public class PlayerCamera : MonoBehaviour 
{
    [SerializeField] private float _sens = 200f;
 
    private float _xRotate = 0;

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;    
    }

    public void RotateCamera(Vector2 mousePosition)
    {
        transform.Rotate(Vector3.up * mousePosition.x * Time.deltaTime * _sens);
        _xRotate -= mousePosition.y * Time.deltaTime * _sens;
        _xRotate = Mathf.Clamp(_xRotate, -80f, 80f);
        Quaternion cameraRotation = Quaternion.Euler(_xRotate, 0, 0);
        Camera.main.transform.localRotation = cameraRotation;
    }    

    private void Update()
    {
        RotateCamera(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
    }

    private void OnDisable() 
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}