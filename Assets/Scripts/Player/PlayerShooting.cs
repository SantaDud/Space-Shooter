using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gun;
    [SerializeField] List<Transform> gunPrefabs;
    
    [SerializeField] float shotDelay = 0.35f;
    private bool canShoot = false;
    int gunIndex = 0;

    private void Start() => gun = Instantiate(gunPrefabs[gunIndex++], transform.parent);

    private void Update()
    {
        if (canShoot)
        {
            canShoot = false;
            CreateBullets();
            Invoke("EnableFire", shotDelay);
        }
    }

    void CreateBullets()
    {
        if (gun.childCount > 0)
            for (int i = 0; i < gun.childCount; i++)
                GetBullet(gun.GetChild(i).position);

        else
            GetBullet(gun.position);
    }

    void GetBullet(Vector3 pos)
    {
        GameObject bullet = ObjectPooling.Instance.GetObject("PlayerBullet");
        bullet.SetActive(true);
        bullet.transform.position = pos;
        bullet.GetComponent<PlayerBullet>().SpeedUp();
    }

    public void UpgradeGun()
    {
        Destroy(gun.gameObject);
        gun = Instantiate(gunPrefabs[gunIndex], transform.parent);
        gunIndex = gunIndex + 1 > 2 ? 2 : gunIndex + 1;
        GameManager.Instance.score += 10;
    }

    private void EnableFire() => canShoot = true;

    public void EnableShooting(bool canShoot = true) => this.canShoot = canShoot;
}
