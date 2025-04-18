using UnityEngine;

public class Stalker : MonoBehaviour
{
    [SerializeField] private StalkerMover _stalkerMover;
    [SerializeField] private Rigidbody _rigidbody;

    private void  FixedUpdate()
    {
        _stalkerMover.MoveToTarget(_rigidbody);
    }
}
