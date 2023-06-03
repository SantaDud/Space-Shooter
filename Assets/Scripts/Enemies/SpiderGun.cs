using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderGun : MonoBehaviour
{
    [SerializeField] GameObject m_bullet;
    [SerializeField] List<Vector3> pos;

    public void ShootGun()
    {
        int numberOfBullets = Random.Range(5, 8);
        float delay = Random.Range(0.1f, 0.2f);
        StartCoroutine(Shoot(numberOfBullets, delay));
    }

    IEnumerator Shoot(int number, float delay)
    {
        transform.parent.GetComponent<Animator>().SetTrigger("Gun");
        
        while (number > 0)
        {
            for (int i = 0; i < pos.Count; i++)
                GetBullet(pos[i]);
            
            number--;

            yield return new WaitForSeconds(delay);
        }
    }

    void GetBullet(Vector3 pos)
    {
        GameObject bullet = ObjectPooling.Instance.GetObject("EnemyBullet");
        bullet.SetActive(true);
        bullet.transform.SetParent(transform);
        bullet.transform.localPosition = pos;
        bullet.GetComponent<RedBullet>().SpeedUp();
        bullet.transform.SetParent(null);
    }
}
