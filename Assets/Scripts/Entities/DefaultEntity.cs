using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEntity : BaseScript
{
    [SerializeField]
    protected int health;
    protected float moveSpeed;
    protected List<GameObject> usableWeapons = new List<GameObject>();
    protected int currentEquipped;
  
    #region GetUsableWeapons, Finds which weapons are usable by this entity and selects a random default weapon to equip on awake.
    protected void GetUsableWeapons()
    {
        if(GetComponentInChildren<MeleeWeapon>()!=null)
        {
            MeleeWeapon melee= GetComponentInChildren<MeleeWeapon>();
            usableWeapons.Add(melee.gameObject);
        }
        if(GetComponentInChildren<ShotGun>()!=null)
        {
            ShotGun shot= GetComponentInChildren<ShotGun>();
            usableWeapons.Add(shot.gameObject);
        }
        if(GetComponentInChildren<SniperGun>()!=null)
        {
            SniperGun snipe= GetComponentInChildren<SniperGun>();
            usableWeapons.Add(snipe.gameObject);
        }
        if(GetComponentInChildren<DefaultGun>()!=null)
        {
            DefaultGun pistol= GetComponentInChildren<DefaultGun>();
            usableWeapons.Add(pistol.gameObject);
        }

        foreach(GameObject weapon in usableWeapons)
        {
            weapon.SetActive(false);
            Debug.Log(weapon);
        }

        if(usableWeapons!=null)
        {
            SwapWeapon(Randomizer(0,usableWeapons.Count));
        }
        else
        {
            Debug.Log("This entity doesn't use a weapon.");
        }
    }
    #endregion

    #region SetEntityStats, used on awake to prepare the entity.
    //Used on awake to prepare the entity.
    protected virtual void SetEntityStats(int hp, float speed)
    {
        health=hp;
        moveSpeed=speed;
        GetUsableWeapons();
    }
   #endregion

    #region Death,TakeDamage. Unused functions cut due to time restraints.
    protected virtual void Death()
    {
        //Default settings for an entity's death
        if(health<=0)
        {
             Debug.Log(this + " just died.");
            Destroy(gameObject);
        }
    }

    protected void TakeDamage(int damageReceieved)
    {
        health-=damageReceieved;
        Debug.Log(this + " took " + damageReceieved + " damage. total health is now: " + health);
        if(health<=0)
        {
            Death();
        }
    }
    #endregion

    #region Move, moves a target with the inputted values.
     public virtual void Move(Vector3 targetLocation, Vector3 currentLocation)
    {
        //moves from the currentLocation to the targetLocation gradually.
        //.normalized might need to be removed in the future because it may affect the move speed.
        Vector3 moveTo=Vector3.Lerp(currentLocation,targetLocation,moveSpeed*Time.deltaTime);
        transform.position += moveTo * moveSpeed * Time.deltaTime;
    }
    #endregion
    
    #region Show,Hide and Swap Weapons.
     public void SwapWeapon(int weaponType)
    {
        HideWeapon();

        currentEquipped=weaponType;
        ShowWeapon();
    }
     protected void ShowWeapon()
    {
        Debug.Log(usableWeapons[currentEquipped]);
       usableWeapons[currentEquipped].SetActive(true);
    }

    protected void HideWeapon()
    {
        usableWeapons[currentEquipped].SetActive(false);
    }
    #endregion
}
