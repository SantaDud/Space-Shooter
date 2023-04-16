using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused = false;

    public void PauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        else
        {
            isPaused = true;
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }
    }
}
