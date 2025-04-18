using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private CameraRotator _cameraRotator;
    [SerializeField] private InputReader _inputReader;

    private void Update()
    {
        _mover.Move(_inputReader.MovementVector,_characterController);
    }

    private void FixedUpdate()
    {
        _cameraRotator.Rotate(_inputReader.LookVector);
    }
}