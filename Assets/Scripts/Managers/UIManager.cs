using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameplayMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject pauseMenu;

    public GameObject playerHealthBar;
    public GameObject enemyHealthBar;

    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI highScore;

    public static UIManager Instance;

    private void Awake()
    {
        if (!Instance)
            Instance = this;

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ResetMenu();
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        gameplayMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void ResetMenu()
    {
        mainMenu.SetActive(true);
        gameplayMenu.SetActive(false);
        pauseMenu.SetActive(false);
        UpdateScore();
        UpdateHighScore();
    }

    public void UpdateScore()
    {
        score.text = GameManager.Instance.score.ToString();
    }

    public void UpdateHighScore()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
