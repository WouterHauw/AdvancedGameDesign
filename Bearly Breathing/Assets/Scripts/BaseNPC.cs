using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNPC : MonoBehaviour {

    private float timer;
    public GameObject player;
    protected bool facingRight;

    public GameObject GetPlayer()
    {
        return player;
    }

    // Update is called once per frame
    void Update()
    {

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
