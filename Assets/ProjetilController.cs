using UnityEngine;

public class ProjetilController : MonoBehaviour
{
    private float damage;

    public void SetProjetilDamage(float damage)
    {
        this.damage = damage;
    }

    public float GetProjetilDamage()
    {
        return damage;
    }
}
