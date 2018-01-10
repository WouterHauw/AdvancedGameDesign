using UnityEngine;
using UnityEngine.AI;

public class BaseNPC : MonoBehaviour
{
    protected GameObject player;
    protected Animator animator;
    protected bool facingLeft;
    private NavMeshAgent _agent;

    public GameObject GetPlayer()
    {
        return player;
    }

    protected virtual void StartNpc()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void UpdateNpc()
    {
        if (_agent.velocity.x > 0 && facingLeft)
        {
            FlipXAxis();
        }
        else if (_agent.velocity.x < 0 && !facingLeft)
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