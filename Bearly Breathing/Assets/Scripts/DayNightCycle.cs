using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    public Light sun;
    private float secondsInFullDay;
    [Range(0, 1)]
    public float currentTimeOfDay;
    [HideInInspector]
    public float timeMultiplier = 1f;
    public int daysSurvived;
   // public bool isDay;
    [SerializeField] private GameObject _player;
    private PlayerController _playerScript;
    [SerializeField] private ScoreManager _scoreScript;

    float sunInitialIntensity;

    void Start()
    {
        InitializeVariables();
        
    }

    private void InitializeVariables()
    {
        _playerScript = _player.GetComponent<PlayerController>();
        currentTimeOfDay = 0.20f;
        sunInitialIntensity = sun.intensity;
        secondsInFullDay = 60f;
    }

    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;        

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f) //beginning of day
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
            DayChanges();
            
        }
        else if (currentTimeOfDay >= 0.73f) // end of day
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
            NightChanges();
            
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }

    private void DayChanges()
    {
        _playerScript._currentScore = 0;
        daysSurvived++;
        Debug.Log("DayChanges");
    }

    private void NightChanges()
    {
        if(_playerScript._currentScore < 10)
        {
            Debug.Log("NightChanges");
            _playerScript.die();
        }
    }
}
