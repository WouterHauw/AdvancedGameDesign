using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField] private PlayerController _player;
    [SerializeField] private GameObject text;
    [SerializeField] private Slider SliderVar;
    private int _currentScore, _requiredScore;

    // Use this for initialization
    void Start()
    {
        InitializeVariables();
        

    }

    private void InitializeVariables()
    {
        _player = _player.GetComponent<PlayerController>();
        _requiredScore = 10;
    }

    // Update is called once per frame
    void Update()
    {
        setScoreSlider();
        text.GetComponent<Text>().text = _player._currentScore + "/" + _requiredScore;
    }



    private void setScoreSlider()
    {
        SliderVar.value = _player._currentScore / _player.maxHealth;
    }
}
