using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerup : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Start()
    {
        rb.velocity = Vector3.down * Powerups.Instance.speed;
        GameManager.cleanUp += CleanUp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PowerUp();
            GameManager.cleanUp -= CleanUp;
            Destroy(gameObject);
        }

        else if (collision.CompareTag("Edge"))
        {
            GameManager.cleanUp -= CleanUp;
            Destroy(gameObject);
        }
    }

    public virtual void PowerUp() { }

    void CleanUp() => Destroy(gameObject);
}
