using UnityEngine;

public class HunterController : BaseNPC
{
    public GameObject bullet;
    public GameObject gun;

    // Use this for initialization
    protected override void StartNpc()
    {
        base.StartNpc();
        facingLeft = false;
    }

    // Update is called once per frame
    protected override void UpdateNpc()
    {
        base.UpdateNpc();
        //TODO fix animator.
        animator.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
        animator.SetBool("isHiding", player.GetComponent<PlayerController>().isHiding);
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
    private void Start()
    {
        StartNpc();
    }
    private void Update()
    {
        UpdateNpc();
    }
}