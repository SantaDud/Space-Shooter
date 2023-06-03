using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player")]
    public GameObject player;
    public Vector2 playerPosition;

    public delegate void CleanUp();
    public static event CleanUp cleanUp; // Used when player dies for game over stuff.

    [Header("Levels")]
    [SerializeField] List<GameObject> levels;
    GameObject currentLevel;

    int nextLevelIndex = 0;
        
    public int score = 0;

    private void Awake()
    {
        Application.targetFrameRate = 200;
        DontDestroyOnLoad(gameObject);

        if (!Instance)
            Instance = this;

        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.Play("MainMenu");
        FindObjectOfType<BackgroundScroll>().SetScrollSpeed(0.05f);
        Instantiate(player, playerPosition, player.transform.rotation);
    }

    public void Play()
    {
        //EnemySpawner.Instance.spawnAnother = true; // Enable to spawn more enemies after each is killed
        //EnemySpawner.Instance.Spawn(); // Spawn the enemy
        FindObjectOfType<PlayerShooting>().EnableShooting(false);

        UIManager.Instance.StartGame();
        UIManager.Instance.SetLevelInfoText(nextLevelIndex + 1);
        Invoke("CreateNextLevel", 1.25f);

        //FindObjectOfType<PlayerShooting>().EnableShooting(); // Enable Player Shooting
        FindObjectOfType<BackgroundScroll>().SetScrollSpeed(0.1f);

        AudioManager.Instance.Stop("MainMenu");
        AudioManager.Instance.Play("Gameplay");
    }

    public void LevelComplete()
    {
        Destroy(currentLevel);

        UIManager.Instance.SetLevelInfoText(nextLevelIndex + 1);
        Invoke("CreateNextLevel", 1.25f);
    }

    void CreateNextLevel()
    {
        currentLevel = Instantiate(levels[nextLevelIndex]);
        currentLevel.SetActive(true);
        nextLevelIndex = nextLevelIndex + 1 < levels.Count ? nextLevelIndex + 1 : 0;
    }

    public void GameOver()
    {
        AudioManager.Instance.Stop("Gameplay");
        AudioManager.Instance.Play("MainMenu");

        cleanUp?.Invoke();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
            PlayerPrefs.SetInt("HighScore", score);
        
        score = 0;

        FindObjectOfType<BackgroundScroll>().SetScrollSpeed(0.05f);
        UIManager.Instance.ResetMenu();
        Instantiate(player, playerPosition, player.transform.rotation);
    }

    public bool IsTrue(float max, float range) => Random.Range(0f, max) > range;
}
