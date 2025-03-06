using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangedEnemy : DefaultEnemy
{
    // Start is called before the first frame update
    void Awake()
    {
        SetEntityStats(30,1f);
    }

    // Update is called once per frame
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

        if(angle<30)
        {
            Debug.Log("Could be in the view cone range.");

            if(signedAngle>-100 && signedAngle < 50)
            {
                Debug.Log("We are in the view cone range.");
                FaceTarget(playerPos.position);
                CanShoot();
            }
        }
    }
}
