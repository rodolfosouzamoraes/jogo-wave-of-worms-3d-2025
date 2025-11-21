using UnityEngine;

public class SpawnEnemyRadio : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] TerminalRadio terminalRadio;
    [SerializeField] float timerWaitSpawn;
    [SerializeField] int maxEnemys;
    private float nextSpawn;
    private int countEnemy = 0;
    private bool isSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextSpawn = Time.timeSinceLevelLoad + timerWaitSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (terminalRadio.TerminalFinished == true) return;

        if (terminalRadio.TerminalActived == true && isSpawn == false)
        {
            isSpawn = true;
        }

        if (Time.timeSinceLevelLoad > nextSpawn && isSpawn == true && countEnemy < maxEnemys) {
            nextSpawn = Time.timeSinceLevelLoad + timerWaitSpawn;

            float distanceToPlayerX = new System.Random().Next(5, 15) * (new System.Random().Next(0, 2) == 0 ? -1 : 1);
            float distanceToPlayerZ = new System.Random().Next(5, 15) * (new System.Random().Next(0, 2) == 0 ? -1 : 1);

            GameObject newEnemy = Instantiate(enemy);
            newEnemy.transform.position = new Vector3(
                PlayerManager.Instance.GetPosition.x + distanceToPlayerX,
                newEnemy.transform.position.y,
                PlayerManager.Instance.GetPosition.z + distanceToPlayerZ
            );

            countEnemy++;
        }
    }
}
