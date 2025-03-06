using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : SpawnWeapons
{
    [SerializeField]
    private GameObject thisWeapon;
    public GameObject[] possibleWeapons = new GameObject[]{};
   
    void Awake()
    {
        SpawnWeapon();
    }

    #region If the collider is the player, give them the correct weapon.
    public void OnTriggerEnter(Collider other)
    {
        if(thisWeapon!=null)
        {
        //If the collider is they player, check if they have the same weapon equipped.
        if(other.GetComponent<Player>())
        {
            Player player=other.GetComponent<Player>();
            Debug.Log("The player is in range to pick up a " + thisWeapon);

                if(thisWeapon.GetComponent<MeleeWeapon>()!=null)
                {
                    player.SwapWeapon(0);
                    Debug.Log("Spawning a sword.");
                }
                else if(thisWeapon.GetComponent<ShotGun>()!=null)
                {
                    player.SwapWeapon(1);
                    Debug.Log("Spawning a shotgun.");
                }
                else if(thisWeapon.GetComponent<SniperGun>()!=null)
                {
                    player.SwapWeapon(2);
                    Debug.Log("Spawning a snipergun.");
                    
                }
                else
                {
                    player.SwapWeapon(3);
                    Debug.Log("Spawning a pistol.");
                    
                }
                Destroy(thisWeapon);
                Destroy(this.gameObject);
        }   
        }
    }
    #endregion

    private void SpawnWeapon()
    {
        thisWeapon=Instantiate(possibleWeapons[Randomizer(0, possibleWeapons.Length)], transform.position, Quaternion.identity);
    }
}
