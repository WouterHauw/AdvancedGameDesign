using UnityEngine;

public class SheepController : BaseNPC
{

    protected override void StartNpc()
    {
        base.StartNpc();
        facingLeft = true;
    }

    protected override void UpdateNpc()
    {
        base.UpdateNpc();
        animator.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
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