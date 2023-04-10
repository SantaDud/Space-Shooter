using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float maxY;
    [SerializeField] float minY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            float x = transform.position.x + speed * Time.deltaTime;
            x = x > maxX ? maxX : x;

            transform.position = new Vector3(x, transform.position.y);
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            float x = transform.position.x - speed * Time.deltaTime;
            x = x < minX ? minX : x;

            transform.position = new Vector3(x, transform.position.y);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            float y = transform.position.y + speed * Time.deltaTime;
            y = y > maxY ? maxY : y;

            transform.position = new Vector3(transform.position.x, y);
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            float y = transform.position.y - speed * Time.deltaTime;
            y = y < minY ? minY : y;
            transform.position = new Vector3(transform.position.x, y);
        }
    }
}
