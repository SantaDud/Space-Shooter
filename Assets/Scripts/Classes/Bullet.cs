using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject afterEffect;
    public int damage = 10;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(Instantiate(afterEffect, transform.position, transform.rotation), .5f);
        Destroy(gameObject);
    }
}
