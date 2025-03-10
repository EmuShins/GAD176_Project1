using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGun : DefaultGun, IGun
{
    void Awake()
    {
        SetGunSpecs();
    }

    public override void SetGunSpecs()
    {
        base.SetGunSpecs();
        magazine=5;
        magazineSize=5;
        maxAmmo=20;
        ammo=maxAmmo;
        bulletShootAmount=1;
        range=2f;
        bulletOffset=new Vector3(0,0.3f,2f);
    }

}
