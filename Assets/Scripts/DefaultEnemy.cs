using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : DefaultEntity
{
    protected Vector3 player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Death()
    {
        if (health<=0)
        {
            DropAmmo();
            //destroy this

        }
    }

    protected void FindPlayer()
    {
        //get object by type Player. set player Vector 3 to that object's location.
    }

    protected virtual void Retreat()
    {
        FindPlayer();
        //moves in the opposite direction of the player.
    }

    protected virtual void DropAmmo()
    {
        //needs to know what ammo is.
    }
}
