using UnityEngine;
using UnityEngine.AI;

public class BaseNPC : MonoBehaviour
{
    protected GameObject player;
    protected Animator animator;
    protected bool facingLeft;
    protected NavMeshAgent agent;

    public GameObject GetPlayer()
    {
        return player;
    }

    public NavMeshAgent GetAgent()
    {
        return agent;
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