using UnityEngine;

public class Test : MonoBehaviour 
{
    [SerializeField] private float _turnSmoothTime = 0.1f;

    private float _turnSmoothVelocity;
    private bool _isRotating;

    private void Update()    
    {
        float targetAngle = Mathf.Atan2(1, 1) * Mathf.Rad2Deg + Player.Instance.transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

        if(transform.rotation.y < targetAngle - 10 || transform.rotation.y > targetAngle + 10)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        else 
        {
            _isRotating = false;
        }
    }
}