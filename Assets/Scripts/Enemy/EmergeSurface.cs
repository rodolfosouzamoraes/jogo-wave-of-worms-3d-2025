using UnityEngine;

public class EmergeSurface : MonoBehaviour
{
    [SerializeField] float speedEmerge;

    void Update()
    {
        transform.localPosition += Vector3.up * Time.deltaTime * speedEmerge;

        if(transform.localPosition.y >= 0)
        {
            transform.localPosition = Vector3.zero;
            Destroy(this);
        }
    }
}
