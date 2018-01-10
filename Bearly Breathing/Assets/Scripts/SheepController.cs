using UnityEngine;

public class SheepController : BaseNPC
{
    private Animator _anim;
    private Transform _playerTransform;
    private Transform _sheepTransform;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _sheepTransform = GameObject.FindGameObjectWithTag("SheepTransform").transform;
    }

    private void Update()
    {
        _anim.SetFloat("distance", Vector3.Distance(_sheepTransform.position, _playerTransform.position));
    }
}