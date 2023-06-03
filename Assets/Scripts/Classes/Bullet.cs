using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject afterEffect;
    public int damage = 10;

    private void Start() => GameManager.cleanUp += CleanUp;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(Instantiate(afterEffect, transform.position, transform.rotation), .5f);
        CleanUp();
    }

    void CleanUp()
    {
        rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
