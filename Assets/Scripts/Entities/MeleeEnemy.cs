using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : DefaultEnemy
{
    protected float attackSpeed=1f;

    void Awake()
    {
        SetEntityStats(100,1f);
    }

    void Update()
    {
        FindAngle();
    }

    protected override void FindAngle()
    {
        Vector3 directionToTarget = playerPos.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);
        float signedAngle = Vector3.SignedAngle(transform.forward, directionToTarget, Vector3.up);
        Debug.DrawRay(transform.position, directionToTarget, Color.blue);

        if(angle<50)
        {
            Debug.Log("Could be in the view cone range.");

            if(signedAngle>-20 && signedAngle < 20)
            {
                Debug.Log("We are in the view cone range.");
                FaceTarget(playerPos.position);
            }
        }
    }
}
