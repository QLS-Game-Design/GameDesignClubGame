using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{

    public Wave[] waves;
    public Enemy enemy1;
    public Enemy enemy2;
    public Enemy enemy3;

    public int bar1; // split 100% to three parts each representing the likelihood of each type of enemy spawning
    public int bar2;

    Wave currentWave;
    int currentWaveNumber;
    public bool finished;

    int enemiesRemaining;
    int enemiesRemainingAlive;
    float nextSpawnTime;

    void Start()
    {
        finished = false;
    }

    void Update()
    {
        if (enemiesRemaining > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemaining--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            Vector3 Pos = new Vector3(transform.position.x, transform.position.y, 0);
            int enemyType = Random.Range(1, 100);
            Enemy spawnedEnemy;
            if (enemyType <= bar1)
            {
                spawnedEnemy = Instantiate(enemy1, Pos, Quaternion.identity) as Enemy;
            }
            else if (enemyType > bar1 && enemyType <= bar2)
            {
                spawnedEnemy = Instantiate(enemy2, Pos, Quaternion.identity) as Enemy;
            }
            else
            {
                spawnedEnemy = Instantiate(enemy3, Pos, Quaternion.identity) as Enemy;
            }

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

    public void NextWave()
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
            finished = true;
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}
