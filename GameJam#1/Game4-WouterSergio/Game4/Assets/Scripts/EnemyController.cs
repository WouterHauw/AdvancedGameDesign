using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public Text enemyScoreText;
    public int enemyScore;

    // Use this for initialization
    void Start()
    {

        enemyScore = 0;
        enemyScoreText.text = ("Score: ") + enemyScore;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bank"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
