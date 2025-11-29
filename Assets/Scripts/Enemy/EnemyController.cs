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

    void Start()
    {
        lifeEnemyMax = lifeEnemy;
        lifeBarEnemy.size = 1;
        agentIA = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (CanvasGameManager.Instance.isGamePaused == true)
        {
            agentIA.destination = transform.position;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red);

            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, rayDistance, layerMask))
            {
                pointCollision = hit.point;
            }

            lifeBarEnemy.gameObject.transform.LookAt(
                new Vector3(
                    transform.position.x - 1.461f,
                    transform.position.y + 0.611f,
                    transform.position.z - 1.368f
                )
            );

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

    private void OnTriggerEnter(Collider other)
    {
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
            CanvasGameManager.EndGame.IncrementWormsKilled();
            Destroy(gameObject);
        }
        lifeBarEnemy.size = lifeEnemy/lifeEnemyMax;
    }
}
