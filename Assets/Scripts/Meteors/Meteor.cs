using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject explosion;
    public float speed;
    
    void Update()
    {
        // Meteor Movement
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player playerInstance = FindObjectOfType<Player>();
            playerInstance.ReduceHealth(200);
            
            Destroy(gameObject);
            Destroy(Instantiate(explosion, transform.position, explosion.transform.rotation), 0.75f);
        }

        else if (collision.CompareTag("Edge"))
            Destroy(gameObject);
    }
}
