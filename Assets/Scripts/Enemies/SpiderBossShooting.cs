using System.Collections;
using UnityEngine;

public class SpiderBossShooting : MonoBehaviour
{
    [SerializeField] SpiderLaser laser;
    [SerializeField] SpiderGun gun;

    private void Start() => Invoke("StartAttack", 1f);

    void StartAttack() => StartCoroutine("Attack");

    IEnumerator Attack()
    {
        while (true)
        {
            float delay = Random.Range(3f, 8f);

            if (Random.Range(0, 2) > 0)
                laser.ShootGun();

            else
                gun.ShootGun();

            yield return new WaitForSeconds(delay);
        }
    }
}
