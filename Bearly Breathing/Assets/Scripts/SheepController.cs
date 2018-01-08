using UnityEngine;

public class SheepController : BaseNPC
{
<<<<<<< HEAD
    
    public Animator anim { get; set; }
=======
    private Animator _anim;
>>>>>>> Development
    private Transform _playerTransform;
    private Transform _sheepTransform;

    private void Start()
    {
        anim = GetComponent<Animator>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _sheepTransform = GameObject.FindGameObjectWithTag("SheepTransform").transform;
    }

    private void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(_sheepTransform.position, _playerTransform.position));
    }
}