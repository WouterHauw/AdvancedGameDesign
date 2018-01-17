using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private Text _hourText;
    private DayNightCycle _cyclus;
    private float _oneHour;

	// Use this for initialization
	private void Start ()
	{
	    _cyclus = FindObjectOfType<DayNightCycle>();
	    _hourText = gameObject.GetComponentInChildren<Text>();
	    _oneHour = 1.0f / 24f;
	}
	
	// Update is called once per frame
	private void Update ()
	{      
	    int hour = (int)(_cyclus.currentTimeOfDay / _oneHour);
	    _hourText.text = hour + ":00";
	}
}
