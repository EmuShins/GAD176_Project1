using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeapon : BaseScript
{
    protected int damage=20;
    protected float range=1f;
    public GameObject[] possibleWeapons = new GameObject[]{};
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void DealDamage()
    {
        
    }

    public IEnumerator WaitRoutine(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
