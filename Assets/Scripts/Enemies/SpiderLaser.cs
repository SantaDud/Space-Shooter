using System.Collections;
using UnityEngine;

public class SpiderLaser : MonoBehaviour
{
    [SerializeField] GameObject m_bullet;
    [SerializeField] Vector3 pos;

    public void ShootGun()
    {
        int numberOfBullets = Random.Range(5, 8);
        float delay = Random.Range(0.01f, 0.05f);
        StartCoroutine(Shoot(numberOfBullets, delay));
    }

    IEnumerator Shoot(int number, float delay)
    {
        transform.parent.GetComponent<Animator>().SetTrigger("Laser");
        
        while (number > 0)
        {
            GetBullet();
            number--;

            yield return new WaitForSeconds(delay);
        }
    }

    void GetBullet()
    {
        GameObject bullet = ObjectPooling.Instance.GetObject("EnemyBullet");
        bullet.SetActive(true);
        bullet.transform.SetParent(transform);
        bullet.transform.localPosition = Vector3.zero;
        bullet.GetComponent<RedBullet>().SpeedUp();
        bullet.transform.SetParent(null);
    }
}
