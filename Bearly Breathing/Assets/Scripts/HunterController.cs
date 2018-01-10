using UnityEngine;

public class HunterController : BaseNPC
{
    public GameObject bullet;
    public GameObject gun;
    private Animator _anim;
    private Transform _hunterTransform;
    private Transform _playerTransform;

    // Use this for initialization
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _hunterTransform = GameObject.FindGameObjectWithTag("HunterTransform").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        //TODO fix animator.
        if(_hunterTransform != null)
        {
            _anim.SetFloat("distance", Vector3.Distance(_hunterTransform.position, _playerTransform.position));
        }
        _anim.SetBool("isHiding", player.GetComponent<PlayerController>().isHiding);
    }

    private void Fire()
    {
        var b = Instantiate(bullet, gun.transform.position, Quaternion.identity);
        b.GetComponent<Rigidbody>().AddForce(gun.transform.forward * 1500);
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
}