using UnityEngine;

public class RedBullet : Bullet
{
    public void SpeedUp() => rb.velocity = Vector2.down * speed;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player playerInstance = FindObjectOfType<Player>();

            if (playerInstance)
                playerInstance.ReduceHealth(damage);
        }

        if (!collision.CompareTag("Enemy") && !collision.CompareTag("Powerup") && !collision.CompareTag("EnemyBullet"))
            base.OnTriggerEnter2D(collision);
    }
}
