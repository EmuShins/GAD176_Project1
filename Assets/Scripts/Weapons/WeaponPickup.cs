using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : SpawnWeapons
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("The player is in range to pick up a weapon.");
        if(other.GetComponent<Player>())
        {
            Player player= other.GetComponentInParent<Player>();
            Debug.Log("The player is in range to pick up a weapon.");
            for(int i =0; i<possibleWeapons.Length; i++)
            {
            if(player.currentEquipped==possibleWeapons[i])
            {


            }
            }
        }
    }
}
