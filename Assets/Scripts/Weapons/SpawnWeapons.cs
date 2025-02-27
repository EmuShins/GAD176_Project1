using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnWeapons : DefaultWeapon
{
    public GameObject spawnVolume;
    // Start is called before the first frame update
    void Start()
    {
        SpawnWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawns 5 random weapons, each in random locations.
    public void SpawnWeapon()
    {
        for(int i=0; i<5; i++)
        {
            Vector3 spawnLocation = new Vector3(Randomizer(-50, 50), 0, Randomizer(-50, 50));
            Instantiate(spawnVolume, spawnLocation, Quaternion.identity);
            Instantiate(possibleWeapons[Randomizer(0, possibleWeapons.Length)], spawnLocation, Quaternion.identity);
        }
    }
}
