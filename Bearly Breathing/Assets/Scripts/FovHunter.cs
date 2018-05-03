using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovHunter : MonoBehaviour
{
    [SerializeField] private float _viewDistance;
    private float _viewAngle;
    private Transform _player;
    //private Color _originalSpotlightColor;
    public Light spotlight;
    public LayerMask viewMask;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _viewAngle = spotlight.spotAngle;
        //_originalSpotlightColor = spotlight.color;

    }

    /*
    void Update()
    {
        if (CanSeePlayer())
        {
            spotlight.color = Color.red;
        }

        else
        {
            spotlight.color = _originalSpotlightColor;
        }
    }
    */
    public bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, _player.position) < _viewDistance)
        {
            Vector3 dirToPlayer = (_player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.right, dirToPlayer);
            if (angleBetweenGuardAndPlayer < _viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, _player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * _viewDistance);
    }

}    
