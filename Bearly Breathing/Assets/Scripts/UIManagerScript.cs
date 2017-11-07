using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject text;
    [SerializeField] private Slider SliderVar;

	// Use this for initialization
	void Start () {
	    player = player.GetComponent<PlayerController>();

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
