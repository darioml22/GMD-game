using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject WinScreen;
    public GameObject LoseScreen;

    private int enemiesAlive;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RegisterEnemy()
    {
        enemiesAlive++;
    }

    public void UnregisterEnemy()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0)
        {
            Win();
        }
    }

    void Win()
    {
        WinScreen.SetActive(true);
        ShowCursor();
        Time.timeScale = 0f;
    }

    public void PlayerDied()
    {
        LoseScreen.SetActive(true);
        ShowCursor();
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}