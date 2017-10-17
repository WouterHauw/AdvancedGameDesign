using System.Collections;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject BearClaw;
    private RaycastHit _hit;
    [SerializeField] private float _bearActiveTime = 3f;
    [SerializeField] private readonly float _range = 10;

    public void Attack()
    {
        var vectorForwards = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, vectorForwards, out _hit, _range))
        {
            if (_hit.transform.gameObject.tag == "Sheep")
            {
                _hit.transform.gameObject.SetActive(false);
                StartCoroutine(BearClawCourotine());
            }
        }
    }

    private IEnumerator BearClawCourotine()
    {
        BearClaw.SetActive(true);
        yield return new WaitForSeconds(_bearActiveTime);
        BearClaw.SetActive(false);

    }
}