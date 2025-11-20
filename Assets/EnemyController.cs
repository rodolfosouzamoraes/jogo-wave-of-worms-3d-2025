using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float lifeEnemy;
    [SerializeField] GameObject fluids;
    [SerializeField] float rayDistance = 10f;
    [SerializeField] Scrollbar lifeBarEnemy;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform targetLook;
    private Vector3 pointCollision;
    private float lifeEnemyMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeEnemyMax = lifeEnemy;
        lifeBarEnemy.size = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Desenha o raio na Scene View (ajuda a depurar)
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red);

        // Cria o Raycast
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, rayDistance, layerMask))
        {
            // Ponto exato de colisão
            pointCollision = hit.point;
        }

        lifeBarEnemy.gameObject.transform.LookAt(
            new Vector3(
                transform.position.x - 1.461f,
                transform.position.y + 0.611f,
                transform.position.z -1.368f
            )
        ); // -1.461, 0.611,-1.368
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Colidiu: {collision.gameObject.tag}");
        if (collision.gameObject.tag.Equals("Projetil"))
        {
            float damage = collision.gameObject.GetComponent<ProjetilController>().GetProjetilDamage();
            DamageEnemy(damage);
        }
    }

    private void DamageEnemy(float damage)
    {
        lifeEnemy -= damage;
        if(lifeEnemy <= 0)
        {
            lifeEnemy = 0;
            GameObject newFluids = Instantiate(fluids);
            newFluids.transform.position = pointCollision;
            Destroy(gameObject);
        }
        lifeBarEnemy.size = lifeEnemy/lifeEnemyMax;
    }
}
