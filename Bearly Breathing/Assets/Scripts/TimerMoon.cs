using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerMoon : MonoBehaviour
{
    public Transform timer;
    [SerializeField]
    private float currentAmount;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Image sunBack;
    private TimerSun timerSun;

    void Start()
    {
        timerSun = FindObjectOfType<TimerSun>();
    }

    void Update()
    {
        if (timerSun.currentAmount <= 0)
        {
            currentAmount -= speed * Time.deltaTime;

            timer.GetComponent<Image>().fillAmount = currentAmount / 100;
        }

        if (currentAmount <= 0)
        {
            sunBack.enabled = false;
            timerSun.currentAmount = 100;
            currentAmount = 100;
            timer.GetComponent<Image>().fillAmount = currentAmount / 100;
        }

    }
}
