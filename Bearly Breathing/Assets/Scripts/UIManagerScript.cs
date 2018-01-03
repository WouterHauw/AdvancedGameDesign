using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private Slider _sliderVar;
    [SerializeField] private GameObject _text;

    // Use this for initialization
    private void Start()
    {
        _player = _player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        SetHealthSlider();
        _text.GetComponent<Text>().text = _player.health + "/" + _player.maxHealth;
    }


    private void SetHealthSlider()
    {
        _sliderVar.value = _player.health / _player.maxHealth;
    }
}