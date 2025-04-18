using UnityEngine;

public class InputReader : MonoBehaviour
{
    private InputActions _inputActions;

    private Vector2 _movementVector;
    private Vector2 _lookVector;

    public Vector2 MovementVector => _movementVector;
    public Vector2 LookVector => _lookVector;

    private void Awake()
    {
        _inputActions = new InputActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void Update()
    {
        _movementVector = _inputActions.Player.Move.ReadValue<Vector2>();
        _lookVector = _inputActions.Player.Look.ReadValue<Vector2>();
    }
}
