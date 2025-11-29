using UnityEngine;

public class DestroyProjetil : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    private void OnTriggerEnter(Collider other)
    {
        particle.transform.SetParent(null);
        particle.transform.localScale = Vector3.one;
        particle.Stop();
        Destroy(particle.gameObject,3f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        particle.transform.SetParent(null);
        particle.transform.localScale = Vector3.one;
        particle.Stop();
        Destroy(particle.gameObject, 3f);
        Destroy(gameObject);
    }
}
