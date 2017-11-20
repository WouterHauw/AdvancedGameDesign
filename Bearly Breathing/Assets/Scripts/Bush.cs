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
        _color = GetComponent<SpriteRenderer>().color;
    }

    //Must be public as its used in interface
    public void ActivateAbility()
    {
        _opacity.a = 0.2f;
        _player.GetComponent<PlayerController>().isHiding = true;
        GetComponent<SpriteRenderer>().color = _opacity;
    }
   
    //Must be public as its used in interface
    public void DeactivateAbility()
    {
        _player.GetComponent<PlayerController>().isHiding = false;
        GetComponent<SpriteRenderer>().color = _color;
    }

 

   /** private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
                
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
        }
    }**/
  
}
