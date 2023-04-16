using UnityEngine;

public class PlayerBullet : Bullet
{
    void Start()
    {
        rb.velocity = Vector2.right * speed;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().ReduceHealth(damage);
        }

        if (!collision.CompareTag("Player"))
            base.OnTriggerEnter2D(collision);
    }
}
