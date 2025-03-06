using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : DefaultEntity, IEnemy
{
    protected Transform playerPos;
    protected float rotationSpeed;


    // Start is called before the first frame update
    void Awake()
    {
        SetEntityStats(50,1f);
    }

    // Update is called once per frame
    void Update()
    {
        FindAngle();

    }

    protected virtual void Retreat()
    {
        //moves in the opposite direction of the player.
    }

    protected virtual void DropAmmo()
    {
        
        //needs to know what ammo is.
    }
    #region IAttack
    public void IAttack()
    {
       /* This code gives a null reference, do not use.
        Debug.Log(currentEquipped);
        switch(currentEquipped)
        {
            case 0:
            {
                return;
            }
            case 1:
            {
                ShotGun shot= this.GetComponentInChildren<ShotGun>();
                Debug.Log(shot);
                shot.IShoot();
                return;
            }
            case 2:
            {
                SniperGun snipe= this.GetComponentInChildren<SniperGun>();
                Debug.Log(snipe);
                snipe.IShoot();
                return;
            }
            case 3:
            {
                DefaultGun pistol= this.GetComponentInChildren<DefaultGun>();
                Debug.Log(pistol);
                pistol.IShoot();
                return;
            }
        }
        */
    }
    #endregion

    protected virtual void CanShoot()
    {
        IAttack();

    }

    protected override void SetEntityStats(int hp, float speed)
    {
        base.SetEntityStats(hp, speed);
        rotationSpeed=10f;
        playerPos=FindFirstObjectByType<Player>().GetComponent<Transform>();

    }

    protected void FaceTarget(Vector3 target)
    {
        
        //Debug.Log("target is:" + target);
        Vector3 faceDirection= target - transform.position;

        float stepTime = rotationSpeed*Time.deltaTime;
        Vector3 finalDirection= Vector3.RotateTowards(transform.forward, faceDirection, stepTime, 0.0f);

        transform.rotation= Quaternion.LookRotation(finalDirection);
      

    }

    protected virtual void FindAngle()
    {
        Vector3 directionToTarget = playerPos.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);
        float signedAngle = Vector3.SignedAngle(transform.forward, directionToTarget, Vector3.up);
        Debug.DrawRay(transform.position, directionToTarget, Color.blue);
        
        if(angle<30)
        {
            Debug.Log("Could be in the view cone range.");

            if(signedAngle>-40 && signedAngle < 40)
            {
                Debug.Log("We are in the view cone range.");
                FaceTarget(playerPos.position);
                CanShoot();
            }
        }
    }

 

}
