using NUnit.Framework;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] float life;
    [SerializeField] GameObject backpack;
    [SerializeField] Renderer backpackRender;
    [SerializeField] float emissiveIntensity = 8f;
    [SerializeField] GameObject body;
    [SerializeField] BoxCollider rifle;
    private Material materialLife;
    private bool sinkInTheSand;


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
        if (CanvasGameManager.EndGame.IsEndGame == true || 
            CanvasGameManager.Instance.isGamePaused == true) return;
        UpdateBackpackColor();
    }

    private void LateUpdate()
    {
        if(sinkInTheSand == true)
        {
            body.transform.Translate(Vector3.down * Time.deltaTime * 0.25f);
        }
    }

    public void DecrementLife(float damage)
    {
        if (CanvasGameManager.EndGame.IsEndGame == true) return;
        life -= damage * Time.deltaTime;
        if (life <= 0){
            life = 0;
            materialLife.color = new Color(0,0,0);
            PlayerManager.Animation.PlayDeathPlayer();
            rifle.gameObject.transform.SetParent(null);
            rifle.enabled = true;
            rifle.gameObject.AddComponent<Rigidbody>();
            CanvasGameManager.EndGame.GameOver();
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

    public void SinkInTheSand()
    {
        sinkInTheSand = true;
    }
}
