using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnWeapons : DefaultWeapon
{
    [SerializeField]
     GameObject spawnVolume;
    
    void Start()
    {
        SpawnWeaponPickup();
    }

    //Instantiates 5 random weapon pickups, each in random locations.
    protected void SpawnWeaponPickup()
    {
        for(int i=0; i<5; i++)
        {
            Vector3 spawnLocation = new Vector3(Randomizer(-50, 50), 0, Randomizer(-50, 50));
            Instantiate(spawnVolume, spawnLocation, Quaternion.identity);
        }
    }
}
