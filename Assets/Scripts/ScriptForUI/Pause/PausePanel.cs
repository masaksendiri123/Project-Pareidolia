using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public GameObject pausePanel;
    public AudioSource rainAudio;

    private bool isPaused = false;
    void Start()
    {  
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;

        if (pausePanel != null)
            pausePanel.SetActive(isPaused);

        if (rainAudio != null)
        {
            if (isPaused)
                rainAudio.Pause();
            else
                rainAudio.UnPause();
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
            TogglePause();
    }
}
