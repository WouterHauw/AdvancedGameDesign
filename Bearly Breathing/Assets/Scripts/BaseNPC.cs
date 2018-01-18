using UnityEngine;
using UnityEngine.AI;

public class BaseNPC : MonoBehaviour
{
    public float distance;
    public GameObject player;
    public NavMeshAgent agent;
    protected Animator animator;
    protected bool facingLeft;
    public float sightRange;


    public Animator GetAnimator()
    {
        return animator;
    }

    protected virtual void StartNpc()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void UpdateNpc()
    {
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