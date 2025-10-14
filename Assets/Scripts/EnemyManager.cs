using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public GameObject currentEnemy;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TrySpawnEnemy()
    {
        if(GameObject.FindGameObjectWithTag("Enemy"))
        {
            return;
        }
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0;
        randomDirection.Normalize();
        Vector3 spawnPosition = player.position + (randomDirection * 49);
        currentEnemy = Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
    }
    private void Update()
    {

    }
    public void EnemyStateHandler(bool flashLight)
    {
        if(currentEnemy != null)
        {
            Enemy enemyScript = currentEnemy.GetComponent<Enemy>();
            if(flashLight)
            {
                enemyScript.currentState = Enemy.EnemyStates.Chasing;
            }
            else
            {
                enemyScript.currentState = Enemy.EnemyStates.Roaming;
            }
        }
    }
}
