using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int health;
    public int requiredScore;
    public int currentScore;
    public bool cooldownExtraSheep;
    public bool cooldownExtraLife;
    public int cooldownDaySheep;
    public int cooldownDayLife;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AdjustScore() { }

}

