﻿using UnityEngine;

public class HunterController : BaseNPC
{
    public GameObject[] waypoints;
    public float accuracy = 3.0f;
    public float shootRange = 5f;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _gun;
    private IHunterState _currentState;
    [SerializeField] private AudioClip _hunterFire;
    private AudioSource _audioSource;

    // Use this for initialization
    protected override void StartNpc()
    {
        _audioSource = GetComponent<AudioSource>();
        base.StartNpc();
        sightRange = 10f;
        facingLeft = false;
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // Update is called once per frame
    protected override void UpdateNpc()
    {
        base.UpdateNpc();
        distance = Vector3.Distance(transform.position, player.transform.position);
        _currentState.Execute();
    }

    public void ChangeState(IHunterState newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;

        _currentState.Enter(this);
    }

    private void Fire()
    {
        _audioSource.PlayOneShot(_hunterFire, 0.5f);
        GameObject _bulletObject = Instantiate(_bullet, _gun.transform.position, Quaternion.identity);
   
        Destroy(_bulletObject, 1f);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 2.0f);
    }

    private void Awake()
    {
        ChangeState(new HunterPatrolState());
    }
    private void Start()
    {
        StartNpc();
    }
    private void Update()
    {
        UpdateNpc();
    }
}