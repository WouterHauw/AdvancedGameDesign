using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AI : MonoBehaviour {

    Animator anim;
    public GameObject player;

    public GameObject GetPlayer()
    {
        return player;
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
    }
}
