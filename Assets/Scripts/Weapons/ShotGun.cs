using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : DefaultGun, IGun
{
    void Awake()
    {
        SetGunSpecs();
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
