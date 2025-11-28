using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float lifeEnemy;
    [SerializeField] GameObject fluids;
    [SerializeField] float rayDistance = 10f;
    [SerializeField] Scrollbar lifeBarEnemy;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float maxDistancePlayer;
    [SerializeField] float valueDamagePlayer;
    [SerializeField] GameObject vfxFluids;
    private NavMeshAgent agentIA;
    private Vector3 pointCollision;
    private float lifeEnemyMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeEnemyMax = lifeEnemy;
        lifeBarEnemy.size = 1;
        agentIA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CanvasGameManager.Instance.isGamePaused == true)
        {
            agentIA.destination = transform.position;
        }
        else
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
                    transform.position.z - 1.368f
                )
            ); // -1.461, 0.611,-1.368

            float calculateDistanceToPlayer = Vector3.Distance(transform.position, PlayerManager.Instance.GetPosition);
            if (calculateDistanceToPlayer > maxDistancePlayer)
            {
                agentIA.destination = PlayerManager.Instance.gameObject.transform.position;
            }
            else
            {
                agentIA.destination = transform.position;
                PlayerManager.Damage.DecrementLife(valueDamagePlayer);
            }
        }            
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Colidiu: {other.gameObject.tag}");
        if (other.gameObject.tag.Equals("Projetil"))
        {
            float damage = other.gameObject.GetComponent<ProjetilController>().GetProjetilDamage();
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
            GameObject newVFX = Instantiate(vfxFluids);
            newVFX.transform.position = transform.position;
            newVFX.transform.localScale *= 2;
            AudioMng.Instance.PlayAudioDeathEnemy();
            Destroy(gameObject);
        }
        lifeBarEnemy.size = lifeEnemy/lifeEnemyMax;
    }
}
