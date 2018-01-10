using UnityEngine;

public class BaseNPC : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rigid;
    private bool _facingRight;

    protected virtual void StartNPC()
    {
        rigid = rigid.GetComponent<Rigidbody>();
        _facingRight = false;
    }
    public GameObject GetPlayer()
    {
        return player;
    }

    protected virtual void UpdateNPC()
    {
        if (rigid.velocity.x > 0 && !_facingRight)
        {
            FlipXAxis();
        }
        else if (rigid.velocity.x < 0 && _facingRight)
        {
            FlipXAxis();
        }
    }

    protected void FlipXAxis()
    {
        //oposite direction
        _facingRight = !_facingRight;

        //get local scale
        var theScale = player.transform.localScale;

        //flip on x axis
        theScale.x *= -1;

        //apply that to the local scale
        player.transform.localScale = theScale;
    }
}