using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterSpeed : MonoBehaviour
{
    private float maxSpeed;
    private Rigidbody2D thisvel;

    void Start() {
        maxSpeed = 3.5f;
        thisvel = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        thisvel.velocity = Vector2.ClampMagnitude(thisvel.velocity, maxSpeed);
    }
}
