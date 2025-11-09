using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject gunBack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DesactiveGunBack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveGunBack()
    {
        gunBack.SetActive(true);
    }

    public void DesactiveGunBack()
    {
        gunBack.SetActive(false);
    }
}
