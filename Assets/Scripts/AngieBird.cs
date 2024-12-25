using UnityEngine;
using UnityEngine.Android;
using System.Collections;
using System.Collections.Generic;

public class AngieBird : MonoBehaviour
{
    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
//kijkt naar de rigidbody component en assigned het aan variable
    }
    private void Start()
    {
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _circleCollider.enabled = false;
    }

    public void LaunchBird(Vector2 direction, float force)
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _circleCollider.enabled = true;

        //apply force
        _rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
    
}
