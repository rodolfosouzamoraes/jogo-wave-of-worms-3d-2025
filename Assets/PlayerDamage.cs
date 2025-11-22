using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] float life;
    [SerializeField] GameObject backpack;
    [SerializeField] Renderer backpackRender;
    [SerializeField] float emissiveIntensity = 8f;
    private Material materialLife;

    private float maxLife;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxLife = life;
        backpack.SetActive(false);
        materialLife = backpackRender.materials[1];
        materialLife.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBackpackColor();
    }

    public void DecrementLife(float damage)
    {
        life -= damage * Time.deltaTime;
        if (life <= 0){
            life = 0;
            materialLife.color = new Color(0,0,0);
            //Game Over
        }
    }   

    public void ActiveBackpack()
    {
        backpack.SetActive(true);
    }

    private void UpdateBackpackColor()
    {
        if (life > 0)
        {
            float porcentagem = life / maxLife;
            Color baseColor = Color.Lerp(Color.red, Color.green, porcentagem);
            Color emissiveColor = baseColor * emissiveIntensity;
            materialLife.SetColor("_EmissionColor", emissiveColor);
        }        
    }
}
