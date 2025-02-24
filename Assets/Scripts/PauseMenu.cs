using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

/*************  ✨ Codeium Command ⭐  *************/
/// <summary>
/// Toggles the paused state of the game. When paused, the time scale is set to 0,
/// the pause menu is activated, and the cursor is unlocked and visible. When unpaused,
/// the time scale is restored, the pause menu is deactivated, and the cursor is locked and hidden.
/// </summary>

/******  00146785-906c-4615-9bd5-173ccc19d861  *******/
    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        pauseMenuPanel.SetActive(isPaused);
        
        // Optional: Lock/unlock cursor based on pause state
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
    }

    public void ResumeGame()
    {
        TogglePause();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToOptions()
    {
        PlayerPrefs.SetInt("ShouldOpenOptions", 1);
        GoToMainMenu();
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}