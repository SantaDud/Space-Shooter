using UnityEngine;

public class RedBullet : Bullet
{
    void Start()
    {
        rb.velocity = Vector2.left * speed;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player playerInstance = FindObjectOfType<Player>();

            if (playerInstance)
                playerInstance.ReduceHealth(damage);
        }

        if (!collision.CompareTag("Enemy"))
            base.OnTriggerEnter2D(collision);
    }
}
