using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : DefaultWeapon, IGun
{
    protected int magazine;
    protected int magazineSize=10;
    protected int ammo;
    protected int maxAmmo=50;
    // Start is called before the first frame update
    void Start()
    {
        ammo=20;
        magazine=5;
    }

    // Update is called once per frame
    void Update()
    {
        IReload();
    }
    //Reloads the gun when pressing R.
    #region IReload
    public void IReload()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
           //find how many bullets need to be reloaded into magazine based off of magazine size.
           if(magazine<magazineSize)
           {
            int reloadAmount = magazineSize-magazine;
            Debug.Log("the amount of bullets to reload is:" + reloadAmount);

            //if there isn't enough bullets to reload the gun fully
            if(ammo<reloadAmount)
            {
                Debug.Log("There wasn't enough ammo to fully reload the gun, reloaded " + ammo + " instead.");
                magazine+=ammo;
                ammo=0;

            }
            //and if there is enough ammo
            else
            {
                ammo-=reloadAmount;
                magazine+=reloadAmount;
                Debug.Log("There was enough ammo to fully reload. the magazine is now: " + magazine + " and the ammo is: " + ammo + ".");
            }

           }
        }
    }
    #endregion

    public void IShoot()
    {
        
    }
}
