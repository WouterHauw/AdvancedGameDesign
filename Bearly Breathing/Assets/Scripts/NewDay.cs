
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NewDay : MonoBehaviour
{

    [SerializeField] private Text _extraSheepText;
    [SerializeField] private Text _dayText;
    [SerializeField] private DayNightCycle _dayNightCycle;

    [SerializeField] private GameObject _newDayMenu;
    [SerializeField] private GameObject _extraLifeButton;
    [SerializeField] private GameObject _bonusNextDayButton;
    [SerializeField] private GameObject _nextDayButton;

    private int _extraSheep;

    // Use this for initialization
    void Start()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        _extraSheepText = _extraSheepText.GetComponent<Text>();
        _dayNightCycle = FindObjectOfType<DayNightCycle>();
        _dayText = _dayText.GetComponent<Text>();

        _newDayMenu.SetActive(false);
        _extraLifeButton.SetActive(false);
        _bonusNextDayButton.SetActive(false);
        _nextDayButton.SetActive(false);
    }


    public void OnNewDay()
    {
        Time.timeScale = 0;
        _newDayMenu.SetActive(true);
        if (GameManager.Instance.currentScore < GameManager.Instance.requiredScore)
        {
            SceneManager.LoadScene("GameOverScreen");
        }
        if (GameManager.Instance.currentScore > GameManager.Instance.requiredScore)
        {
            _extraLifeButton.SetActive(true);
            _bonusNextDayButton.SetActive(true);
            _extraSheep = GameManager.Instance.currentScore - GameManager.Instance.requiredScore;
            _extraSheepText.text = (GameManager.Instance.currentScore - GameManager.Instance.requiredScore).ToString() ;
        }
        else
        {
            _extraLifeButton.SetActive(false);
            _bonusNextDayButton.SetActive(false);
            _nextDayButton.SetActive(true);
            _extraSheepText.text = "You didn't collect any extra sheep. Maybe tomorrow!";
        }
        _dayText.text = (_dayNightCycle.daysSurvived + 1).ToString();
    }

    public void OnClickExtraLife()
    {
        GameManager.Instance.health++;
        _newDayMenu.SetActive(false);
        _extraLifeButton.SetActive(false);
        _bonusNextDayButton.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickBonusNextDay()
    {
        GameManager.Instance.requiredScore -= _extraSheep;
        _newDayMenu.SetActive(false);
        _extraLifeButton.SetActive(false);
        _bonusNextDayButton.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickNextDay()
    {
        _nextDayButton.SetActive(false);
        Time.timeScale = 1;
    }
}
