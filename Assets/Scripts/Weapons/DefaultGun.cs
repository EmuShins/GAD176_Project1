using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : DefaultWeapon, IGun
{
    protected int magazine;
    protected int magazineSize;
    protected int ammo;
    protected int maxAmmo;
    protected int bulletShootAmount;
    protected float bulletSpeed;
    protected Vector3 bulletOffset;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
       SetGunSpecs();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Reloads the gun when pressing R.
    #region IReload
    public void IReload()
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
    #endregion
    //Instantiates the bullet at the bulletOffset, then moves it in a direction with rigidbody velocity.
    #region IShoot
    public void IShoot()
    {
        
            Debug.Log("Left mouse button pressed.");
            if(magazine>0)
            {
                //saves the original bulletOffset so the next shots won't progressively change position.
                Vector3 originalOffset= bulletOffset;

                //if there is more than one bullet, move the bulletOffset to create a star pattern.
                for(int i=0; i<=bulletShootAmount-1; i++)
                {
                    switch(i)
                    {
                        case 1:
                        {
                            bulletOffset= new Vector3(bulletOffset.x+0.3f, bulletOffset.y, bulletOffset.z);
                            break;
                        }
                        case 2:
                        {
                            bulletOffset= new Vector3(bulletOffset.x-0.6f, bulletOffset.y, bulletOffset.z);
                            break;
                        }
                        case 3:
                        {
                            bulletOffset= new Vector3(bulletOffset.x+0.2f, bulletOffset.y+0.3f, bulletOffset.z);
                            break;
                        }
                        case 4:
                        {
                            bulletOffset= new Vector3(bulletOffset.x+0.2f, bulletOffset.y, bulletOffset.z);
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }

                //instantiate the bullet at the right position.
               GameObject bullet=Instantiate(bulletPrefab, transform.position+bulletOffset, transform.rotation);
               Destroy(bullet, range);

               //give the bullet the right velocity
               Rigidbody bulletRigid= bullet.GetComponent<Rigidbody>();
               bulletRigid.velocity = this.transform.forward * bulletSpeed;

               //take the bullet out of the magazine
               magazine-=1;
                }
                //reset the bulletOffset position.
                bulletOffset=originalOffset;
            }
            else
            {
                Debug.Log("There was no ammo left, could not shoot.");
            }
    }
    #endregion
    
    //called at start to set the various gun's different specs.
    public virtual void SetGunSpecs()
    {
        magazine=10;
        magazineSize=10;
        ammo=maxAmmo;
        maxAmmo=50;
        bulletShootAmount=1;
        bulletSpeed=50f;
        bulletOffset=new Vector3(0,0.3f,1.3f);
        range=1f;
    }

}
