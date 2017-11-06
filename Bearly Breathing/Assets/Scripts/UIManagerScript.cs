using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
    [SerializeField] private PlayerController player;
    public GameObject text;
    [SerializeField] private Slider SliderVar;

	// Use this for initialization
	void Start () {
        SliderVar = GetComponent<Slider>();
        player = player.GetComponent<PlayerController>();
        text = GameObject.Find("HealthText");
       
    }
	
	// Update is called once per frame
	void Update () {
        setHealthSlider();
        text.GetComponent<Text>().text = player.health + "/" + player.maxHealth;
    }

   

    private void setHealthSlider()
    {
        SliderVar.value = player.health / player.maxHealth;
    }
}
