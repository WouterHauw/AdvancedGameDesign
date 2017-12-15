using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : BaseNPC
{
    
    public Animator anim { get; set; }
    private Transform _playerTransform;
    private Transform _sheepTransform;

    void Start()
    {
        anim = GetComponent<Animator>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _sheepTransform = GameObject.FindGameObjectWithTag("SheepTransform").transform;
    }

    void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(_sheepTransform.position, _playerTransform.position));
    }


}
