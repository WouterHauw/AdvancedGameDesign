using UnityEngine;
using UnityEngine.UI;

public class TimerMoon : MonoBehaviour
{
    public Transform timer;
    [SerializeField] private float _currentAmount;
    [SerializeField] private float _speed;
    [SerializeField] private Image _sunBack;

    private TimerSun _timerSun;

    private void Start()
    {
        _timerSun = FindObjectOfType<TimerSun>();
    }

    private void Update()
    {
        if (_timerSun.currentAmount <= 0)
        {
            _currentAmount -= _speed * Time.deltaTime;

            timer.GetComponent<Image>().fillAmount = _currentAmount / 100;
        }

        if (_currentAmount <= 0)
        {
            _sunBack.enabled = false;
            _timerSun.currentAmount = 100;
            _currentAmount = 100;
            timer.GetComponent<Image>().fillAmount = _currentAmount / 100;
        }
    }
}