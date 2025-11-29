using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ParticleDistanceLimiter : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(PlayerManager.Instance.FluidPackage);
    }
}
