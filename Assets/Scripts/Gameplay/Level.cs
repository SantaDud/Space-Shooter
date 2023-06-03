using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int levelNumber;
    public List<GameObject> enemyPatterns;
    GameObject currentWavePattern;

    public int numberOfWaves; // Number of waves in the level
    int currentWave;          // Current wave number
    int totalWaveEnemies;     // Number of total enemies in a wave
    int waveEnemiesKilled;    // Number of enemies killed in the wave

    bool canShoot = true;
    bool creatingNextWave = false;

    private void Start()
    {
        currentWave = 1;
        SetWave();
    }

    private void Update()
    {
        if (canShoot)
        {
            canShoot = false;

            if (currentWavePattern.transform.childCount > 0)
                currentWavePattern.transform.GetChild(Random.Range(0, currentWavePattern.transform.childCount)).GetComponentInChildren<EnemyShooting>().Shoot();
            
            Invoke("SetTrue", Random.Range(2.5f, 3.5f));
        }

        if (currentWavePattern.transform.childCount == 0 && !creatingNextWave)
        {
            creatingNextWave = true;
            Invoke("NextWave", 1f);
        }
    }

    public void UpdateKills() => waveEnemiesKilled++;

    public void NextWave()
    {
        currentWave++;
        waveEnemiesKilled = 0;

        if (currentWave == numberOfWaves + 1)
            GameManager.Instance.LevelComplete();

        else
            SetWave();

        creatingNextWave = false;
    }

    void SetWave()
    {
        UIManager.Instance.SetWaveInfoText(currentWave, numberOfWaves);

        Destroy(currentWavePattern);

        currentWavePattern = Instantiate(enemyPatterns[Random.Range(0, enemyPatterns.Count)]);
        totalWaveEnemies = currentWavePattern.transform.childCount;
        waveEnemiesKilled = 0;

        Invoke("EnableMovement", 2f);
    }

    void EnableMovement()
    {
        for (int i = 0; i < currentWavePattern.transform.childCount; i++)
            currentWavePattern.transform.GetChild(i).GetComponent<EnemyMovement>().StartMovement();
    }

    void SetTrue() => canShoot = true;
}
