using UnityEngine;
using UnityEngine.AI;

public class BaseNPC : MonoBehaviour
{
    public float distance;
    public GameObject player;
    public NavMeshAgent agent;
    protected Animator animator;
    protected bool facingLeft;


    protected virtual void StartNpc()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void UpdateNpc()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (agent.velocity.x > 0 && facingLeft)
        {
            FlipXAxis();
        }
        else if (agent.velocity.x < 0 && !facingLeft)
        {
            FlipXAxis();
        }
    }

    private void FlipXAxis()
    {
        //oposite direction
        facingLeft = !facingLeft;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    
}