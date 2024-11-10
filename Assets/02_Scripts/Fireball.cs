using System;
using UnityEngine;


public class Fireball : MonoBehaviour
{
    public Rigidbody2D ballToFire;

    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
