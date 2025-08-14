using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    bool isPaused;

    void Update()
    {
        if (pauseMenu != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
        }
    }

    public void ResumeBtn()
    {
        isPaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
    }

    public void MenuBtn()
    {
        isPaused = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
