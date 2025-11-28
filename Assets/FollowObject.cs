using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] GameObject target;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(
            target.transform.position.x,
            transform.position.y,
            target.transform.position.z
        );
    }
}
