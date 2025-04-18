using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _strafeSpeed = 3f;
    [SerializeField] private float _gravityFactor = 2f;

    private Vector3 _horizontalVelocity;
    private Vector3 _verticalVelocity;

    public void Move(Vector2 direction, CharacterController characterController)
    {
        Vector3 forwardVector = ProjectVector(_cameraTransform.forward);
        Vector3 rightVector = ProjectVector(_cameraTransform.right);

        if (characterController.isGrounded)
        {
             _horizontalVelocity = forwardVector * direction.y * _speed + rightVector * _strafeSpeed * direction.x;
            _verticalVelocity = Vector3.down * -Physics.gravity.y;
        }
        else
        {
            _horizontalVelocity = characterController.velocity;
            _horizontalVelocity.y = 0;
            _verticalVelocity += Physics.gravity * _gravityFactor * Time.deltaTime;
        }

        characterController.Move((_horizontalVelocity + _verticalVelocity) * Time.deltaTime);
    }

    private Vector3 ProjectVector(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, Vector3.up).normalized;
    }
}
