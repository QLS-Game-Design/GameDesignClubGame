using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{

    public Wave[] waves;
    public Enemy enemy;

    Wave currentWave;
    int currentWaveNumber;

    int enemiesRemaining;
    int enemiesRemainingAlive;
    float nextSpawnTime;

    void Start()
    {

        NextWave();
    }

    void Update()
    {
        if (enemiesRemaining > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemaining--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            Vector3 Pos = new Vector3(transform.position.x, transform.position.y, 0);
            Enemy spawnedEnemy = Instantiate(enemy, Pos, Quaternion.identity) as Enemy;

            spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }

    void OnEnemyDeath()
    {
        enemiesRemainingAlive--;

        if (enemiesRemainingAlive == 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        currentWaveNumber++;
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];

            enemiesRemaining = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemaining;
        }
        else
        {
            // SceneManager.LoadScene(); // load next level here
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}
