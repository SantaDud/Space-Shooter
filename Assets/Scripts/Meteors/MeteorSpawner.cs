using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public static MeteorSpawner Instance;
    public GameObject meteor;
    public float yPos;
    [SerializeField] float minX;
    [SerializeField] float maxX;
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

    //private void Start()
    //{
    //    Spawn();
    //}

    public void Spawn()
    {
        GameObject meteorInstance = Instantiate(meteor, new Vector3(Random.Range(minX, maxX), yPos), Quaternion.identity);
        meteorInstance.GetComponent<Rigidbody2D>().AddTorque(torque);
    }
}
