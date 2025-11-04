using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    private Vector3 _offset;
    public float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        var targetPosition = target.position +_offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}
