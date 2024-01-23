using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEProjectile : Bullet
{
    [SerializeField] private float _scaleIncrement = 0.1f;

    // AoE projectiles does not destroy on collisions
    private void OnCollisionEnter2D(Collision2D collision) { }
    private void OnTriggerEnter2D(Collider2D collision) { }

    protected override void Update()
    { 
        // expand in size
        var newScale = new Vector3(transform.localScale.x + (_scaleIncrement * Time.deltaTime), transform.localScale.y + (_scaleIncrement * Time.deltaTime), transform.localScale.z);

        transform.localScale = newScale;
        base.Update();
    }
}
