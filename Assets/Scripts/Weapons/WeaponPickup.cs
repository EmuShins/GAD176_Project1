using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : SpawnWeapons
{
    [SerializeField]
    private GameObject thisWeapon;
    public GameObject[] possibleWeapons = new GameObject[]{};
   
    // Start is called before the first frame update
    void Start()
    {
        SpawnWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        //If the collider is they player, check if they have the same weapon equipped.
        if(other.GetComponent<Player>())
        {
            Debug.Log("The player is in range to pick up a " + thisWeapon);

                if(thisWeapon.GetComponent<MeleeWeapon>()!=null)
                {
                    Debug.Log(thisWeapon);
                    player.SwapWeapon(0);
                }
                if(thisWeapon.GetComponent<ShotGun>()!=null)
                {
                    Debug.Log(thisWeapon);
                    player.SwapWeapon(1);
                }
                if(thisWeapon.GetComponent<SniperGun>()!=null)
                {
                    Debug.Log(thisWeapon);
                    player.SwapWeapon(2);
                }
                if(thisWeapon.GetComponent<DefaultGun>()!=null)
                {
                    Debug.Log(thisWeapon);
                    player.SwapWeapon(3);
                }

        }
    }

    private void SpawnWeapon()
    {
        thisWeapon=Instantiate(possibleWeapons[Randomizer(0, possibleWeapons.Length)], transform.position, Quaternion.identity);
    }
}
