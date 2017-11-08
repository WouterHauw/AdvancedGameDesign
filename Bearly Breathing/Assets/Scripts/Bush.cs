using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour {
    //keep the different states seperate, no need to make it more complex
    [SerializeField] private Color _color, _opacity;
    [SerializeField] private GameObject _player;


    // Use this for initialization
    void Start () {
        InitializeVariables();
       


    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void InitializeVariables()
    {
        
        _color = GetComponent<SpriteRenderer>().color;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _opacity.a = 0.2f;
            //TODO:: cannot be done when the player has one or more hunter that are in chase state. 
            //    _player.isHiding = true;
            Debug.Log("test");
           // other.gameObject.transform.localScale = new Vector3(1f, 0, 1);
            GetComponent<SpriteRenderer>().color = _opacity;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //   _player.isHiding = false;
            GetComponent<SpriteRenderer>().color = _color;
        }
    }
  
}
