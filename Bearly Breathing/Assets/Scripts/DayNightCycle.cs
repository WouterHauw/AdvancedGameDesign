using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0, 1)] public float currentTimeOfDay;

    [SerializeField]
    private InputScript _inputScript;
    [SerializeField]
    private DifficultyChanger _difficultyChanger;
    private NewDay _newDay;
    private bool _dayHasBeenChanged;

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
        _difficultyChanger.ChangeDifficultyOnNewDay(daysSurvived);
    }

    private void InitializeVariables()
    {
        currentTimeOfDay = 0.25f;
        _sunInitialIntensity = sun.intensity;
        _secondsInFullDay = 60f;
        daysSurvived = 0;
        _inputScript = FindObjectOfType<InputScript>();
        _difficultyChanger = FindObjectOfType<DifficultyChanger>();
        _newDay = FindObjectOfType<NewDay>();
        _dayHasBeenChanged = false;
        _playerScript = _player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        UpdateSun();

        currentTimeOfDay += Time.deltaTime / _secondsInFullDay * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
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

        if (currentTimeOfDay >= 0.75f && currentTimeOfDay <= 0.76f)
        {
            NightChanges();
            _dayHasBeenChanged = false;
        }

        if (currentTimeOfDay >= 0.23f && currentTimeOfDay <= 0.24f)
        {
            if (!_dayHasBeenChanged)
            {
                DayChanges();
                _dayHasBeenChanged = true;
            }
        }

        sun.intensity = _sunInitialIntensity * intensityMultiplier;
    }

    private void DayChanges()
    {
        _inputScript.walkingSpeed = 8;
        _newDay.OnNewDay();
        daysSurvived++;
        Debug.Log("DayChanges");
        GameManager.Instance.currentScore = 0;
        DestroyOnDay();
        _difficultyChanger.ChangeDifficultyOnNewDay(daysSurvived);
    }

    private void DestroyOnDay()
    {
        var sheep = GameObject.FindGameObjectsWithTag("SheepTransform");

        foreach (var item in sheep)
        {
            item.SetActive(false);
        }

        var hunter = GameObject.FindGameObjectsWithTag("HunterTransform");

        foreach (var item in hunter)
        {
            Destroy(item);
        }
    }



    private void NightChanges()
    {
        _inputScript.walkingSpeed = 4;
        if (GameManager.Instance.currentScore < GameManager.Instance.requiredScore)
        {
            Debug.Log("NightChanges");
            //  _playerScript.Die();
        }
    }
}