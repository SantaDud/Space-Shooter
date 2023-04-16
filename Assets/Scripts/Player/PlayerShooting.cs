using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gun;
    [SerializeField] float shotDelay = 0.2f;
    private bool canShoot = false;

    private void Update()
    {
        if (/*Input.GetButton("Jump") && */canShoot)
        {
            canShoot = false;
            Instantiate(bulletPrefab, gun.position, Quaternion.identity);
            Invoke("SetTrue", shotDelay);
        }
    }

    public void SetTrue()
    {
        canShoot = true;
    }
}
