using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public GameObject currentEnemy;
    public float enemyTime;
    public float waitingDelay = 2f;
    public bool enemySpawned;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TrySpawnEnemy()
    {
        if(GameObject.FindGameObjectWithTag("Enemy") || GlobalVariableManager.Instance.gameEnd)
        {
            return;
        }
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0;
        randomDirection.Normalize();
        Vector3 spawnPosition = player.position + (randomDirection * 29);
        currentEnemy = Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
    }
    private void Update()
    {
        if(enemySpawned)
        {
            enemyTime += Time.deltaTime;
        }
    }
    public void EnemyStateHandler(bool flashLight)
    {
        if(currentEnemy != null)
        {
            enemySpawned = true;
            Enemy enemyScript = currentEnemy.GetComponent<Enemy>();
            if(enemyTime > waitingDelay)
            {
                if (flashLight)
                {
                    
                    enemyScript.currentState = Enemy.EnemyStates.Chasing;
                }
                else
                {
                    
                    enemyScript.currentState = Enemy.EnemyStates.Roaming;
                }
            }
            else
            {
                
                enemyScript.currentState = Enemy.EnemyStates.Waiting;
            }
        }
        else
        {
            enemySpawned = false;
            enemyTime = 0;
        }
    }
}
