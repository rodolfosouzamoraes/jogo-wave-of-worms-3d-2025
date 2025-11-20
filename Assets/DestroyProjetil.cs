using UnityEngine;

public class DestroyProjetil : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
