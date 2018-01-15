using UnityEngine;

public class HunterController : BaseNPC
{
    public GameObject[] waypoints;
    public float accuracy = 3.0f;
    public float shootRange = 10f;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _gun;
    private IHunterState _currentState;

    // Use this for initialization
    protected override void StartNpc()
    {
        base.StartNpc();
        sightRange = 20f;
        facingLeft = false;
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // Update is called once per frame
    protected override void UpdateNpc()
    {
        base.UpdateNpc();
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
        var b = Instantiate(_bullet, _gun.transform.position, Quaternion.identity);
        b.GetComponent<Rigidbody>().AddForce(_gun.transform.forward * 1500);
        Destroy(b, 1f);
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