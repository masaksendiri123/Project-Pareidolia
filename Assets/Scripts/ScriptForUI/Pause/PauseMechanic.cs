using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public AudioSource rainAudio;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;

            if (rainAudio != null)
            {
                if (isPaused)
                    rainAudio.Pause();
                else
                    rainAudio.UnPause();
            }
        }
    }
}


