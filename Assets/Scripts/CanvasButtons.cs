using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButtons : MonoBehaviour
{
    #region Fields
    [SerializeField] GameObject gameplayCanvas;
    [SerializeField] GameObject gameoverCanvas;
    [SerializeField] GameObject pauseCanvas;

    static CanvasButtons instance;
    #endregion

    #region Methods
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            Time.timeScale = 0f;
        }    
    }
    public void Play()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        gameplayCanvas.SetActive(true);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
        Application.OpenURL("https://yuriy-danyliuk.itch.io/");
#else
        Application.Quit();
#endif
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public static void Gameover()
    {
        Time.timeScale = 0f;
        instance.gameplayCanvas.SetActive(false);
        instance.gameoverCanvas.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
        gameplayCanvas.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
        gameplayCanvas.SetActive(true);
    }
    #endregion
}