using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float positionX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    private void Awake()
    {
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            float spawnDelay = Random.Range(10f, 20f);
            yield return new WaitForSeconds(spawnDelay);

            float y = Random.Range(minY, maxY);
            Instantiate(enemyPrefab, new Vector2(positionX, y), enemyPrefab.transform.rotation);
        }
    }
}
