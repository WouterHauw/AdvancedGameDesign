using UnityEngine;

public class SheepController : BaseNPC
{
    private Animator _anim;
    private Transform _playerTransform;
    private Transform _sheepTransform;

    protected override void StartNPC()
    {
        
        _anim = GetComponent<Animator>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _sheepTransform = GameObject.FindGameObjectWithTag("SheepTransform").transform;
    }

    protected virtual void UpdateNPC()
    {
        _anim.SetFloat("distance", Vector3.Distance(_sheepTransform.position, _playerTransform.position));
    }
    private void Start()
    {
        StartNPC();
    }
    private void Update()
    {
        UpdateNPC();
    }
}