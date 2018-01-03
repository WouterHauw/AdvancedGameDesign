using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0, 1)] public float currentTimeOfDay;

    public int daysSurvived;

    public Light sun;

    [HideInInspector] public float timeMultiplier = 1f;

    // public bool isDay;
    [SerializeField] private GameObject _player;

    private PlayerController _playerScript;
    private float _secondsInFullDay;

    private float _sunInitialIntensity;

    private void Start()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        _playerScript = _player.GetComponent<PlayerController>();
        currentTimeOfDay = 0.20f;
        _sunInitialIntensity = sun.intensity;
        _secondsInFullDay = 60f;
    }

    private void Update()
    {
        UpdateSun();

        currentTimeOfDay += Time.deltaTime / _secondsInFullDay * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            DayChanges();
            NightChanges();
            currentTimeOfDay = 0;
        }
    }

    private void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler(currentTimeOfDay * 360f - 90, 170, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f) //beginning of day
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f) // end of day
        {
            intensityMultiplier = Mathf.Clamp01(1 - (currentTimeOfDay - 0.73f) * (1 / 0.02f));
        }

        sun.intensity = _sunInitialIntensity * intensityMultiplier;
    }

    private void DayChanges()
    {
        daysSurvived++;
        Debug.Log("DayChanges");
    }

    private void NightChanges()
    {
        if (_playerScript.currentScore < 10)
        {
            Debug.Log("NightChanges");
            _playerScript.Die();
        }
        else
        {
            _playerScript.currentScore = 0;
        }
    }
}