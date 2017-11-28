using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : BaseNPC
{
    Animator anim;
    public GameObject bullet;
    public GameObject gun;
    private Transform playerTransform;
    private Transform hunterTransform;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        hunterTransform = GameObject.FindGameObjectWithTag("HunterTransform").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO fix animator.
        anim.SetFloat("distance", Vector3.Distance(hunterTransform.position, playerTransform.position));
        anim.SetBool("isHiding", player.GetComponent<PlayerController>().isHiding);
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(gun.transform.forward * 1500);
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
