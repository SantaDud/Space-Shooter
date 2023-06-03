using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    public void Shoot()
    {
        transform.parent.GetComponent<Animator>().SetTrigger("Attack");
        Invoke("GetBullet", .7f);
    }

    void GetBullet()
    {
        GameObject bullet = ObjectPooling.Instance.GetObject("EnemyBullet");
        bullet.SetActive(true);
        bullet.transform.position = transform.position;
        bullet.GetComponent<RedBullet>().SpeedUp();
    }
}
