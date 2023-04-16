using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float maxY;
    [SerializeField] float minY;

    public float stutterGuard;
    public float smoothnessFactor;

    void Update()
    {
        Vector3 touchPos = transform.position;
        Vector3 previousTouchPos = transform.position;
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos = new Vector3(pos.x, pos.y, 0.0f);
        }

        if (Input.GetAxis("Horizontal") > 0 || touchPos.x > (previousTouchPos.x + stutterGuard))
        {
            float x = transform.position.x + speed * (Time.deltaTime / smoothnessFactor);
            x = x > maxX ? maxX : x;

            transform.position = new Vector3(x, transform.position.y);
        }

        else if (Input.GetAxis("Horizontal") < 0 || touchPos.x < previousTouchPos.x - stutterGuard)
        {
            float x = transform.position.x - speed * (Time.deltaTime / smoothnessFactor);
            x = x < minX ? minX : x;

            transform.position = new Vector3(x, transform.position.y);
        }

        if (Input.GetAxis("Vertical") > 0 || touchPos.y > (previousTouchPos.y + stutterGuard))
        {
            float y = transform.position.y + speed * (Time.deltaTime / smoothnessFactor);
            y = y > maxY ? maxY : y;

            transform.position = new Vector3(transform.position.x, y);
        }

        else if (Input.GetAxis("Vertical") < 0 || touchPos.y < (previousTouchPos.y - stutterGuard))
        {
            float y = transform.position.y - speed * (Time.deltaTime / smoothnessFactor);
            y = y < minY ? minY : y;

            transform.position = new Vector3(transform.position.x, y);
        }

        previousTouchPos = touchPos;
    }
}
