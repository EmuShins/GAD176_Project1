using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : SpawnWeapons
{
    private GameObject thisWeapon;
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
            Player player= other.GetComponentInParent<Player>();
            Debug.Log("The player is in range to pick up a weapon.");
            for(int i =0; i<possibleWeapons.Length; i++)
            {
        
            }

        }
    }

    public void SpawnWeapon()
    {
        thisWeapon=Instantiate(possibleWeapons[Randomizer(0, possibleWeapons.Length)], transform.position, Quaternion.identity);
    }
}
