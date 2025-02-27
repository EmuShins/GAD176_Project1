using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnWeapons : DefaultWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWeapon()
    {
        Vector3 spawnLocation = new Vector3(Randomizer(-50, 50), 0, Randomizer(-50, 50));
       Instantiate(possibleWeapons[Randomizer(0, possibleWeapons.Length)], spawnLocation, Quaternion.identity);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other==other.GetComponent<Player>())
        {
            Player player= other.GetComponentInParent<Player>();
            Debug.Log("The player is in range to pick up a weapon.");
            for(int i =0; i<=possibleWeapons.Length; i++)
            {
                if(player.currentEquipped==possibleWeapons[i])
            {



            }
            }
        }
    }
}
