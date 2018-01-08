using UnityEngine.UI;
using UnityEngine;

public class TimerSun : MonoBehaviour
{
    public Transform timer;
    public float currentAmount;
    [SerializeField]
    public float speed;
    [SerializeField]
    private Image sunBack;

    void Update()
    {
        if (currentAmount <= 100)
        {
            sunBack.enabled = true;
            currentAmount -= speed * Time.deltaTime;
            timer.GetComponent<Image>().fillAmount = currentAmount / 100;
        }


        if (currentAmount <= 0)
        {
            currentAmount = 0;
        }

    }
}
