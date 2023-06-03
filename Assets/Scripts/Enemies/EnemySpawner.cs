using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    float positionX;
    [SerializeField] float positionY;
    [SerializeField] float minX;
    [SerializeField] float maxX;
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
            positionX = Random.Range(minX, maxX);
            Destroy(Instantiate(spawnEffect, new Vector2(positionX, positionY), enemyPrefab.transform.rotation), 0.5f);
            Invoke("CreateEnemy", 0.75f);
        }
    }

    public void CreateEnemy()
    {
        Instantiate(enemyPrefab, new Vector2(positionX, positionY), enemyPrefab.transform.rotation);
    }
}
