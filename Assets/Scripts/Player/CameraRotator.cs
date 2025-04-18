using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _verticalMinVector = -89;
    [SerializeField] private float _verticalMaxVector = 89;
    [SerializeField] private float _verticalSensetivity;
    [SerializeField] private float _horizontalSensetivity;

    private Transform _transform;
    
    private Vector3 _horizontalRotation;

    private float _cameraVerticalAngel;

    private void Awake()
    {
        _transform = transform;
        _cameraVerticalAngel = _cameraTransform.localEulerAngles.x;
    }

    public void Rotate(Vector2 lookVector) 
    {
        _cameraVerticalAngel -= lookVector.y * _verticalSensetivity;
        _cameraVerticalAngel = Mathf.Clamp(_cameraVerticalAngel, _verticalMinVector, _verticalMaxVector);
        _cameraTransform.localEulerAngles = _cameraVerticalAngel * Vector3.right; 
        _horizontalRotation = Vector3.up * lookVector.x * _horizontalSensetivity;
        _transform.Rotate(_horizontalRotation);
    }
}
