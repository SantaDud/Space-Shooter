using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float positionX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    float positionY;
    public GameObject spawnEffect;
    public bool spawnAnother = true;

    public static EnemySpawner Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void Spawn()
    {
        if (spawnAnother)
        {
            positionY = Random.Range(minY, maxY);
            Destroy(Instantiate(spawnEffect, new Vector2(positionX, positionY), enemyPrefab.transform.rotation), 0.5f);
            Invoke("CreateEnemy", 0.75f);
        }
    }

    public void CreateEnemy()
    {
        Instantiate(enemyPrefab, new Vector2(positionX, positionY), enemyPrefab.transform.rotation);
    }
}
