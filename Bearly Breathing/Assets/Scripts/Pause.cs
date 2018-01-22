using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _attackButton;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _pauseMenu;
    private bool _isPaused;

    // Use this for initialization
    private void Start()
    {
        _isPaused = false;
        _pauseMenu.SetActive(false);
    }

    public void OnClickPauseButton()
    {
        _isPaused = !_isPaused;
        if (!_isPaused)
        {
            return;
        }
        Time.timeScale = 0;
        HideButtons();
    }

    public void OnClickResumeButton()
    {
        _isPaused = !_isPaused;
        if (_isPaused)
        {
            return;
        }
        Time.timeScale = 1;
        ShowButtons();
    }

    public void OnClickRestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("2DScene");
    }

    public void OnClickSettingsButton()
    {
        //here a transition to settings screen
    }

    public void OnClickExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    private void HideButtons()
    {
        _attackButton.SetActive(false);
        _pauseButton.SetActive(false);
        _pauseMenu.SetActive(true);
    }

    private void ShowButtons()
    {
        _attackButton.SetActive(true);
        _pauseButton.SetActive(true);
        _pauseMenu.SetActive(false);
    }
}