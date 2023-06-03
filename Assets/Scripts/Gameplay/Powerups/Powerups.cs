using UnityEngine;

public class Powerups : MonoBehaviour
{
    public GameObject[] powerUps;
    public float speed;

    public static Powerups Instance;

    private void Awake()
    {
        if (!Instance)
            Instance = this;

        else
            Destroy(gameObject);
    }

    public void SpawnPowerup(Vector3 position)
    {
        //if (Random.Range(0f, 1f) >= 0.5f)
            Instantiate(powerUps[/*Random.Range(0, powerUps.Length)*/0], position, Quaternion.identity);
    }

    public void UpgradeGun() => FindObjectOfType<PlayerShooting>().UpgradeGun();
}
