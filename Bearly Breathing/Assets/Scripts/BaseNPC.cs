using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNPC : MonoBehaviour {

    Animator anim;
    private float timer;
    public GameObject player;
    public GameObject bullet;
    public GameObject gun;
    protected bool facingRight;

    public GameObject GetPlayer()
    {
        return player;
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

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Hunter"))
        {
            //TODO fix animator.
            anim.SetFloat("distance", Vector3.Distance(transform.parent.position, player.transform.parent.position));
            anim.SetBool("isHiding", player.GetComponent<PlayerController>().isHiding);
        }
    }
    protected void FlipXAxis()
    {
        //oposite direction
        facingRight = !facingRight;

        //get local scale
        var theScale = player.transform.localScale;

        //flip on x axis
        theScale.x *= -1;

        //apply that to the local scale
        player.transform.localScale = theScale;
    }
}
