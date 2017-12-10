using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : BaseNPC
{

    private Animator _anim;
    private Transform _playerTransform;
    private Transform _sheepTransform;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _sheepTransform = GameObject.FindGameObjectWithTag("SheepTransform").transform;
    }

    void Update()
    {

        _anim.SetFloat("distance", Vector3.Distance(_sheepTransform.position, _playerTransform.position));
    }


}
