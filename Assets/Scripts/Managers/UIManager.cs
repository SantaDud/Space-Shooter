using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject pauseMenu;

    [Header("HealthBars")]
    public GameObject playerHealthBar;

    [Header("Score")]
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI highScore;

    [Header("Gameplay")]
    [SerializeField] GameObject gameplayMenu;
    public TMPro.TextMeshProUGUI waveText;
    public TMPro.TextMeshProUGUI levelText;

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

    private void Start() => ResetMenu();

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

    public void SetLevelInfoText(int level)
    {
        FindObjectOfType<PlayerShooting>().EnableShooting(false);

        levelText.text = $"{level}";
        levelText.transform.parent.GetComponent<Animator>().SetTrigger("LevelSlide");
        Time.timeScale = 0.5f;
        Invoke("CorrectTimeScale", .5f);
    }

    public void SetWaveInfoText(int currentWaveNumber, int totalWaves)
    {
        FindObjectOfType<PlayerShooting>().EnableShooting(false);
        waveText.text = $"{currentWaveNumber} / {totalWaves}";
        waveText.transform.parent.GetComponent<Animator>().SetTrigger("Slide");
        Time.timeScale = 0.5f;
        Invoke("CorrectTimeScale", .5f);
        Invoke("EnablePlayerShooting", .5f);
    }

    public void UpdateScore() => score.text = GameManager.Instance.score.ToString();

    public void UpdateHighScore() => highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    void CorrectTimeScale() => Time.timeScale = 1f;

    void EnablePlayerShooting() => FindObjectOfType<PlayerShooting>().EnableShooting();
}
