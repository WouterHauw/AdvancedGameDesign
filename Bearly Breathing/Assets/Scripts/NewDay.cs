
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NewDay : MonoBehaviour
{
    [SerializeField] private Text _title;
    [SerializeField] private Text _extraSheepText;
    [SerializeField] private Text _sheepText;
    [SerializeField] private Text _dayText;
    [SerializeField] private DayNightCycle _dayNightCycle;

    [SerializeField] private GameObject _newDayMenu;
    [SerializeField] private GameObject _extraLifeButton;
    [SerializeField] private GameObject _bonusNextDayButton;
    [SerializeField] private GameObject _nextDayButton;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _exitGameButton;

    private bool _once;


    private int _extraSheep;
    private GameManager gameManager;

    // Use this for initialization
    private void Start()
    {
        InitializeVariables();
    }

    private void Update()
    {
        if (GameManager.Instance.health <= 0 && _once )
        {
            Time.timeScale = 0;
            _newDayMenu.SetActive(true);
            GameOver();
            _once = false;
        }
    }

    private void InitializeVariables()
    {
        _extraSheepText = _extraSheepText.GetComponent<Text>();
        _dayNightCycle = FindObjectOfType<DayNightCycle>();
        _dayText = _dayText.GetComponent<Text>();
        gameManager = GameManager.Instance;
        _newDayMenu.SetActive(false);
        _extraLifeButton.SetActive(false);
        _bonusNextDayButton.SetActive(false);
        _nextDayButton.SetActive(false);
        _restartButton.SetActive(false);
        _exitGameButton.SetActive(false);
        _once = true;
    }


    public void OnNewDay()
    {
        Time.timeScale = 0;
        _newDayMenu.SetActive(true);

        _dayText.text = (_dayNightCycle.daysSurvived + 1).ToString();

        if (_dayNightCycle.daysSurvived - gameManager.cooldownDaySheep >= 10)
        {
            gameManager.cooldownExtraSheep = false;
        }

        if (_dayNightCycle.daysSurvived - gameManager.cooldownDayLife >= 5)
        {
            gameManager.cooldownExtraLife = false;
        }

        if (GameManager.Instance.currentScore > GameManager.Instance.requiredScore && !gameManager.cooldownExtraLife && !gameManager.cooldownExtraSheep)
        {
            if (!gameManager.cooldownExtraLife)
            {
                _extraLifeButton.SetActive(true);
            }
            if (!gameManager.cooldownExtraSheep)
            {
                _bonusNextDayButton.SetActive(true);
            }
            _title.text = "GOOD MORNING";
            _sheepText.text = "Extra Sheep";
            _extraSheep = GameManager.Instance.currentScore - GameManager.Instance.requiredScore;
            _extraSheepText.text = (GameManager.Instance.currentScore - GameManager.Instance.requiredScore).ToString();

        }
        else if (GameManager.Instance.currentScore < GameManager.Instance.requiredScore)
        {
            GameOver();
        }
        else
        {
            _sheepText.text = "Needed Sheep";
            _extraLifeButton.SetActive(false);
            _bonusNextDayButton.SetActive(false);
            _nextDayButton.SetActive(true);
            _extraSheepText.text = "You didn't collect any extra sheep. Maybe tomorrow!";
        }



    }
    //Made sure this happen sonly once every 5 days, See if you want to merge it.
    public void OnClickExtraLife()
    {
        gameManager.cooldownExtraLife = true;
        gameManager.cooldownDayLife = _dayNightCycle.daysSurvived;

        GameManager.Instance.health++;
        _newDayMenu.SetActive(false);
        _extraLifeButton.SetActive(false);
        _bonusNextDayButton.SetActive(false);
        Time.timeScale = 1;
    }
    //Made sure you can only use this once every 10 days. See if you want to merge it.
    public void OnClickBonusNextDay()
    {
        int newscore = gameManager.requiredScore - _extraSheep;
        int requiredScore = gameManager.requiredScore;
        gameManager.cooldownExtraSheep = true;
        gameManager.cooldownDaySheep = _dayNightCycle.daysSurvived;

        if (newscore < requiredScore / 2)
        {

            gameManager.requiredScore = requiredScore / 2;
        }
        else
        {
            requiredScore -= _extraSheep;
        }

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
    public void OnClickRetry()
    {
        _newDayMenu.SetActive(false);
        _restartButton.SetActive(false);
        _exitGameButton.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("2DScene");
    }
    public void OnClickQuit()
    {
        _newDayMenu.SetActive(false);
        _restartButton.SetActive(false);
        _exitGameButton.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    private void GameOver()
    {
        _title.text = "GAME OVER!";
        _sheepText.text = "Needed Sheep";
        _restartButton.SetActive(true);
        _exitGameButton.SetActive(true);
        _extraSheepText.text = (GameManager.Instance.currentScore - GameManager.Instance.requiredScore).ToString();
    }
}
