using UnityEngine;

public class EmergeSurface : MonoBehaviour
{
    [SerializeField] float speedEmerge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
