using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {
    private int _daysSurvived, _highScore;
    [SerializeField] private GameObject text;

    // Use this for initialization
    void Start () {
        _daysSurvived = PlayerPrefs.GetInt("DaysSurvived");
        if(_daysSurvived > _highScore)
        {
            _highScore = _daysSurvived;
            text.GetComponent<Text>().text = "Days Survived: " + _daysSurvived;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (_daysSurvived > _highScore)
        {
            _highScore = _daysSurvived;
        }
    }

    public void RestartGame()
    {
        PlayerPrefs.SetInt("DaysSurvived", 0);
        SceneManager.LoadScene("2DScene");
    }
    public void GoToMainMenu()
    {
        PlayerPrefs.SetInt("DaysSurvived", 0);
        SceneManager.LoadScene("MainMenu");
    }
}

