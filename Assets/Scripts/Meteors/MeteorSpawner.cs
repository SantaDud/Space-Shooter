using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public static MeteorSpawner Instance;
    public GameObject meteor;
    public float xPos;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    public float torque;

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

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject meteorInstance = Instantiate(meteor, new Vector3(xPos, Random.Range(minY, maxY)), Quaternion.identity);
        meteorInstance.GetComponent<Rigidbody2D>().AddTorque(torque);
    }
}
