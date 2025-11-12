using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public Transform target;
    private Vector3 _offset;
    public float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    private void Awake()
    {
        if(Instance == null)
        {
            _offset = transform.position - target.position;
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        var targetPosition = target.position +_offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
