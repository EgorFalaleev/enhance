using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooter : Shooter
{
    public bool IsWeaponAttached { get; set; }

    private void Update()
    {
        // weapon can shoot only if attached to player
        if (IsWeaponAttached)
            ShootWithCooldown(_bullet, _bulletInitialPosition, _shootCooldown);
    }
}
