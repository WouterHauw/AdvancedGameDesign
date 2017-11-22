using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField] private PlayerController _player;
    [SerializeField] private DayNightCycle cycle;
    [SerializeField] private GameObject text;
    [SerializeField] private Slider SliderVar;
    private int _currentScore, _requiredScore, _survived;
    

    // Use this for initialization
    void Start()
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
    void Update()
    {
        setScoreSlider();
        text.GetComponent<Text>().text = _player._currentScore + "/" + _requiredScore;
        _survived = cycle.daysSurvived;
    }



    private void setScoreSlider()
    {
        SliderVar.value = _player._currentScore / _requiredScore;
    }
}
