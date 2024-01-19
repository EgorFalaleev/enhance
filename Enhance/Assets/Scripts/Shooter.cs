using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour 
{
    public abstract Transform GetTarget();
    protected abstract void Shoot(GameObject bulletPrefab, Transform bulletInitialPos);
}
