using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    public void StartMovement() => StartCoroutine("RandomMovement");

    IEnumerator RandomMovement()
    {
        while (true)
        {
            float movementDelay = Random.Range(2.5f, 7.25f);
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);

            if (transform.position.x < x)
                StartCoroutine(MoveRightToPosition(x));

            else if (transform.position.x > x)
                StartCoroutine(MoveLeftToPosition(x));

            if (transform.position.y < y)
                StartCoroutine(MoveUpToPosition(y));

            else if (transform.position.y > y)
                StartCoroutine(MoveDownToPosition(y));

            yield return new WaitForSeconds(movementDelay);
        }
    }

    IEnumerator MoveLeftToPosition(float positionX)
    {
        while (transform.position.x > positionX)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveRightToPosition(float positionX)
    {
        while (transform.position.x < positionX)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveUpToPosition(float positionY)
    {
        while (transform.position.y < positionY)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveDownToPosition(float positionY)
    {
        while (transform.position.y > positionY)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
