using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ParticleDistanceLimiter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerManager.Instance.FluidPackage);
    }
}
