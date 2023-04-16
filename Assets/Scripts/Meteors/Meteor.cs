using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject explosion;
    public float speed;
    bool canDestroy = false;

    private void Start()
    {
        Invoke("SetCanDestroy", 1.5f);
    }

    void Update()
    {
        // Meteor Movement
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerInstance = FindObjectOfType<Player>();
            playerInstance.ReduceHealth(200);
            
            Destroy(gameObject);
            Destroy(Instantiate(explosion, transform.position, explosion.transform.rotation), 0.75f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Edge"))
            if (canDestroy)
                Destroy(gameObject);
    }

    void SetCanDestroy()
    {
        canDestroy = true;
    }
}
