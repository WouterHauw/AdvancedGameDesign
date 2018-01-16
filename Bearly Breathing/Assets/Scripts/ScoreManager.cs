using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _requiredScore, _survived;

    [SerializeField] private PlayerController _player;
    [SerializeField] private DayNightCycle _cycle;
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
        
    }

    // Update is called once per frame
    private void Update()
    {
        _text.GetComponent<Text>().text = GameManager.Instance.currentScore + "/" + GameManager.Instance.requiredScore;
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
}