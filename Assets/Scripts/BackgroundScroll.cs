using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private MeshRenderer bg;

    void Update() => bg.material.mainTextureOffset += new Vector2(0, scrollSpeed * Time.deltaTime);

    public void SetScrollSpeed(float speed) => scrollSpeed = speed;
}
