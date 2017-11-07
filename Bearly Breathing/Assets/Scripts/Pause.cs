using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public bool isPaused;
    public GameObject attackButton;
    public GameObject moveButton;
    public GameObject pauseMenu;
    public GameObject pauseButton;

    // Use this for initialization
    void Start () {
        isPaused = false;
        pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickPauseButton()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            Time.timeScale = 0;
            HideButtons();
        }
    }

    public void OnClickResumeButton()
    {
        isPaused = !isPaused;
        if (!isPaused)
        {
            Time.timeScale = 1;
            ShowButtons();
        }
    }

    private void HideButtons()
    {
        attackButton.SetActive(false);
        moveButton.SetActive(false);
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    private void ShowButtons()
    {
        attackButton.SetActive(true);
        moveButton.SetActive(true);
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
