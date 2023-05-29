using UnityEngine;

public abstract class Follower : MonoBehaviour
{
    [SerializeField] protected Transform _targetTransform;
    [SerializeField] protected Vector3 _offset;
    [SerializeField] protected float _smoothing = 1f;

    protected void Move (float deltaTime)
    {
        if(_targetTransform == null)
            return;

        Vector3 nextPosition = Vector3.Lerp (transform.position, _targetTransform.position + _offset, deltaTime * _smoothing);

        transform.position = nextPosition;
    }

    public void SetFollowTransform(Transform followTransform)
    {
        _targetTransform = followTransform;
    }

    public void SetOffset(Vector3 offset)
    {
        _offset = offset;
    }

    public void SetSmoothing (float smoothing)
    {
        _smoothing = smoothing;
    }
}
