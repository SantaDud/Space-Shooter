using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject explosion;
    public float speed;
    bool canDestroy = false;

    private void Start()
    {
        Invoke("SetCanDestroy", 1.35f);
        GameManager.cleanUp += CleanUp;
    }

    void Update()
    {
        // Meteor Movement
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerInstance = FindObjectOfType<Player>();
            playerInstance.ReduceHealth(200);
            
            Destroy(gameObject);
            GameManager.cleanUp -= CleanUp;
            Destroy(Instantiate(explosion, transform.position, explosion.transform.rotation), 0.75f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Edge") && canDestroy)
        {
            GameManager.cleanUp -= CleanUp;
            Destroy(gameObject);
        }
    }

    void SetCanDestroy() => canDestroy = true;

    void CleanUp() => Destroy(gameObject);
}
