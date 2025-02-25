using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : DefaultGun, IGun
{
    // Start is called before the first frame update
    void Start()
    {
        SetGunSpecs();
    }

    // Update is called once per frame
    void Update()
    {
        IShoot();
    }
   
    public override void SetGunSpecs()
    {
        base.SetGunSpecs();
        magazine=20;
        magazineSize=20;
        bulletShootAmount=5;
        range=.5f;
    }

}
