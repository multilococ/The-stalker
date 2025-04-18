using UnityEngine;

public class StalkerMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _speed;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void MoveToTarget(Rigidbody rigidbody)
    {
        if (_target != null)
        {
            Vector3 direction = _target.position - _transform.position;
            Vector3 moveVector;

            if (direction.magnitude > _minDistance)
                moveVector = direction.normalized * _speed;
            else
                moveVector = Vector3.zero;

            moveVector.y = rigidbody.velocity.y;
            rigidbody.velocity = moveVector;
        }
    }
}