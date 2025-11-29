using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public static PlayerController Controller;
    public static PlayerAnimation Animation;
    public static PlayerDamage Damage;
    public static PlayerFire Fire;

    private void Awake()
    {
        if(Instance == null)
        {
            Controller = GetComponent<PlayerController>();
            Animation = GetComponent<PlayerAnimation>();
            Fire = GetComponent<PlayerFire>();
            Damage = GetComponent<PlayerDamage>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    [SerializeField] Transform fluidPackage;

    public Transform FluidPackage
    {
        get { return fluidPackage; }
    }

    public Vector3 GetPosition
    {
        get { return transform.position; }
    }
}
