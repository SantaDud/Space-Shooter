using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    public Vector2 playerPosition;
    public int score = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (!Instance)
            Instance = this;

        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 200;
        AudioManager.Instance.Play("MainMenu");
        Instantiate(player, playerPosition, player.transform.rotation);
    }

    public void Play()
    {
        EnemySpawner.Instance.spawnAnother = true; // Enable to spawn more enemies after each is killed
        EnemySpawner.Instance.Spawn(); // Spawn the enemy
        FindObjectOfType<PlayerShooting>().SetTrue(); // Enable Player Shooting

        UIManager.Instance.StartGame();

        AudioManager.Instance.Stop("MainMenu");
        AudioManager.Instance.Play("Gameplay");
    }

    public void GameOver()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
            PlayerPrefs.SetInt("HighScore", score);
        
        score = 0;
        
        UIManager.Instance.ResetMenu();
        Instantiate(player, playerPosition, player.transform.rotation);
    }
}
