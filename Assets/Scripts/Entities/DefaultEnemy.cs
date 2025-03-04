using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : DefaultEntity, IEnemy
{
    

    // Start is called before the first frame update
    void Awake()
    {
        SetEntityStats(50,1f);
        ShowWeapon();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Retreat()
    {
        //moves in the opposite direction of the player.
    }

    protected virtual void DropAmmo()
    {
        
        //needs to know what ammo is.
    }

    public void IAttack()
    {

    }

 

}
