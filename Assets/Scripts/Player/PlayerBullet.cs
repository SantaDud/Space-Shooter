using UnityEngine;

public class PlayerBullet : Bullet
{
    //public void SpeedUp(float angle) => rb.velocity = new Vector2(Mathf.Cos(angle) * speed, Mathf.Sin(angle) * speed);
    public void SpeedUp() => rb.velocity = Vector2.up * speed;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            collision.transform.GetComponent<Enemy>().ReduceHealth(damage);

        if (!collision.CompareTag("Player") && !collision.CompareTag("Powerup"))
            base.OnTriggerEnter2D(collision);
    }
}
