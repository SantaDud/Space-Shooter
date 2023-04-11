using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float shootDelay = 0.1f;
    Transform gun;
    bool canShoot = true;

    private void Start()
    {
        gun = GetComponent<Transform>();
    }

    void Update()
    {
        if (canShoot)
        {
            canShoot = false;
            Instantiate(bullet, gun.position, bullet.transform.rotation);
            Invoke("SetTrue", shootDelay);
        }
    }

    private void SetTrue() { canShoot = true; }
}
