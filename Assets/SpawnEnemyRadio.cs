using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SpawnEnemyRadio : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] TerminalRadio terminalRadio;
    [SerializeField] float timerWaitSpawn;
    [SerializeField] int maxEnemys;
    private float nextSpawn;
    private int countEnemy = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextSpawn = Time.timeSinceLevelLoad + timerWaitSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (terminalRadio.TerminalFinished == true) return;

        if (Time.timeSinceLevelLoad > nextSpawn && terminalRadio.TerminalActived == true && countEnemy < maxEnemys) {
            nextSpawn = Time.timeSinceLevelLoad + timerWaitSpawn;

            float distanceX = new System.Random().Next(3, 10);
            float distanceZ = new System.Random().Next(3, 10);

            float positionZ = Random.Range(
                terminalRadio.transform.position.z - distanceZ,
                terminalRadio.transform.position.z + distanceZ
            );

            float positionX = Random.Range(
                terminalRadio.transform.position.x - distanceX,
                terminalRadio.transform.position.x + distanceX
            );

            NavMeshHit positionNavMesh;
            NavMesh.SamplePosition(
                new Vector3(positionX, 0, positionZ),
                out positionNavMesh,
                Mathf.Infinity,
                1
            );

            GameObject newEnemy = Instantiate(enemy);

            NavMeshAgent agent = newEnemy.GetComponent<NavMeshAgent>();
            agent.enabled = false; 
            newEnemy.transform.position = positionNavMesh.position;
            agent.enabled = true;

            countEnemy++;
        }
    }
}
