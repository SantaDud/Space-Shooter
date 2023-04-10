using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private MeshRenderer bg;
    
    void Update()
    {
        bg.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}
