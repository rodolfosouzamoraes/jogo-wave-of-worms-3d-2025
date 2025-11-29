using UnityEngine;

public class DestroyObjectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
