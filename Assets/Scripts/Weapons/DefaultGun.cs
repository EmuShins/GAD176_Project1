using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : DefaultWeapon, IGun
{
    protected int magazine;
    protected int magazineSize=10;
    protected int ammo;
    protected int maxAmmo=50;
    protected float bulletSpeed=10f;
    protected Vector3 bulletOffset;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        ammo=20;
        magazine=5;
        range=10f;
    }

    // Update is called once per frame
    void Update()
    {
        IReload();
        IShoot();
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
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button pressed.");
            if(magazine>0)
            {
                //instantiate the bullet at the right position.
                bulletOffset=new Vector3(0,0.3f,1);
               GameObject bullet=Instantiate(bulletPrefab, transform.position+bulletOffset, transform.rotation);
               Destroy(bullet, 3);

               //give the bullet the right velocity
               Rigidbody bulletRigid= bullet.GetComponent<Rigidbody>();
               bulletRigid.velocity = this.transform.forward * bulletSpeed;

               //take the bullet out of the magazine
               magazine-=1;
            }
            else
            {
                Debug.Log("There was no ammo left, could not shoot.");
            }
        }
    }

}
