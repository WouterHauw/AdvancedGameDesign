using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField] private DayNightCycle _cycle;
    [SerializeField] private GameObject _text;
    public Slider sliderVar;
    private int _survived;
   // public int requiredScore;

    // Use this for initialization
    void Start()
    {
        InitializeVariables();
        sliderVar.value = 0;

    }

    private void InitializeVariables()
    {
        DontDestroyOnLoad(this);
        // _requiredScore = 5;
        // SliderVar.maxValue = 5;
        sliderVar.maxValue = GameManager.Instance.requiredScore;

    }

    // Update is called once per frame
    void Update()
    {
        SetScoreSlider();
        _text.GetComponent<Text>().text = GameManager.Instance.currentScore + "/" + GameManager.Instance.requiredScore;
        if(_cycle.daysSurvived > _survived) {
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
        sliderVar.value = GameManager.Instance.currentScore;
    }


}
