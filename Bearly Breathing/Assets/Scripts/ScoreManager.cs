using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _requiredScore, _survived;

    [SerializeField] private PlayerController _player;
    [SerializeField] private DayNightCycle _cycle;
    [SerializeField] private Slider _sliderVar;
    [SerializeField] private GameObject _text;


    // Use this for initialization
    private void Start()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        DontDestroyOnLoad(this);
        _player = _player.GetComponent<PlayerController>();
        _requiredScore = 10;
    }

    // Update is called once per frame
    private void Update()
    {
        SetScoreSlider();
        _text.GetComponent<Text>().text = _player.currentScore + "/" + _requiredScore;
        if (_cycle.daysSurvived > _survived)
        {
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        _survived = _cycle.daysSurvived;
        PlayerPrefs.SetInt("DaysSurvived", _survived);
    }

    private void SetScoreSlider()
    {
        _sliderVar.value = _player.currentScore / _requiredScore;
    }
}