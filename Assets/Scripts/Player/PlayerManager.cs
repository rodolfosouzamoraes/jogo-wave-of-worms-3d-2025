using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public static PlayerController Controller;
    public static PlayerAnimation Animation;

    private void Awake()
    {
        if(Instance == null)
        {
            Controller = GetComponent<PlayerController>();
            Animation = GetComponent<PlayerAnimation>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
