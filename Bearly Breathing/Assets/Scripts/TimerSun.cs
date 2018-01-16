using UnityEngine;
using UnityEngine.UI;

public class TimerSun : MonoBehaviour
{
    public float currentAmount;
    [SerializeField] public float speed;
    public Transform timer;

    [SerializeField] private Image _sunBack;

    private void Update()
    {
        if (currentAmount <= 100)
        {
            _sunBack.enabled = true;
            currentAmount -= speed * Time.deltaTime;
            timer.GetComponent<Image>().fillAmount = currentAmount / 100;
        }

        if (currentAmount <= 0)
        {
            currentAmount = 0;
        }
    }
}