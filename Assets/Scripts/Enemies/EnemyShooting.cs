using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float shootDelay = 0.1f;
    [SerializeField] int minBullets = 5;
    [SerializeField] int maxBullets = 10;
    int numberOfBullelts;
    int firedBullets = 0;
    Transform gun;
    bool canShoot = true;

    private void Start()
    {
        gun = transform;
        numberOfBullelts = Random.Range(minBullets, maxBullets);
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            
            if (firedBullets >= numberOfBullelts)
            {
                firedBullets = 0;
                numberOfBullelts = Random.Range(minBullets, maxBullets);
                Invoke("SetTrue", Random.Range(1.5f, 3.0f));
            }

            else
            {
                firedBullets++;
                Instantiate(bullet, gun.position, bullet.transform.rotation);
                Invoke("SetTrue", shootDelay);
            }
        }
    }

    private void SetTrue() { canShoot = true; }
}
