using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] float life;
    [SerializeField] GameObject backpack;

    private float maxLife;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxLife = life;
        backpack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecrementLife(float damage)
    {
        life -= damage * Time.deltaTime;
        if (life <= 0){
            life = 0;
            //Game Over
        }
    }   

    public void ActiveBackpack()
    {
        backpack.SetActive(true);
    }
}
