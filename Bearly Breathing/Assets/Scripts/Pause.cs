﻿using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour {

    [SerializeField]private bool _isPaused;
    [SerializeField] private GameObject _attackButton;
    [SerializeField] private GameObject _moveButton;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseButton;

    // Use this for initialization
    void Start () {
        _isPaused = false;
        _pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickPauseButton()
    {
        _isPaused = !_isPaused;
        if(_isPaused)
        {
            Time.timeScale = 0;
            HideButtons();
        }
    }

    public void OnClickResumeButton()
    {
        _isPaused = !_isPaused;
        if (!_isPaused)
        {
            Time.timeScale = 1;
            ShowButtons();
        }
    }

    public void OnClickMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void HideButtons()
    {
        _attackButton.SetActive(false);
        _moveButton.SetActive(false);
        _pauseButton.SetActive(false);
        _pauseMenu.SetActive(true);
    }

    private void ShowButtons()
    {
        _attackButton.SetActive(true);
        _moveButton.SetActive(true);
        _pauseButton.SetActive(true);
        _pauseMenu.SetActive(false);
    }
}
