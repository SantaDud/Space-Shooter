using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    private void Start()
    {
        StartCoroutine("RandomMovement");
    }

    IEnumerator RandomMovement()
    {
        while (true)
        {
            float movementDelay = Random.Range(0.5f, 2.0f);
            float y = Random.Range(minY, maxY);

            if (transform.position.y < y)
                MoveUpToPosition(y);

            else if (transform.position.y > y)
                MoveDownToPosition(y);

            yield return new WaitForSeconds(movementDelay);
        }
    }

    void MoveUpToPosition(float positionY)
    {
        while (transform.position.y < positionY)
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
    }

    void MoveDownToPosition(float positionY)
    {
        while (transform.position.y > positionY)
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
    }
}
