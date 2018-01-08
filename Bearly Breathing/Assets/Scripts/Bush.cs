using UnityEngine;

public class Bush : MonoBehaviour, AbilityInterface {
    //keep the different states seperate, no need to make it more complex
    [SerializeField] private Color _color, _opacity;
    [SerializeField] private GameObject _player;


    // Use this for initialization
    void Start () {
        InitializeVariables();      
     }
    
    //Must be public as its used in interface

    public void InitializeVariables()
    {
        _player = this.gameObject;
        _color = GetComponent<SpriteRenderer>().color;
    }

    //Must be public as its used in interface
    public void ActivateAbility(GameObject aObject, Animator anim)
    {
        _opacity.a = 0.2f;
        _player.GetComponent<PlayerController>().isHiding = true;
        aObject.GetComponent<SpriteRenderer>().color = _opacity;
    }
   
    //Must be public as its used in interface
    public void DeactivateAbility(GameObject aObject, Animator anim)
    {
        _player.GetComponent<PlayerController>().isHiding = false;
        aObject.GetComponent<SpriteRenderer>().color = _color;
    }
  
}
