using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public static MeteorSpawner Instance;
    public GameObject meteor;
    public float xPos;
    [SerializeField] float minY;
    [SerializeField] float maxY;

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
        Instantiate(meteor, new Vector3(xPos, Random.Range(minY, maxY)), Quaternion.identity);
    }
}
