using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpriteController : MonoBehaviour {

    public float RotationAmount = 1f;

    private Rigidbody2D rb;

    void Start () {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    void Update () {
        float verticalSpeed = rb.velocity.y;

        transform.rotation = Quaternion.Euler(0, 0, verticalSpeed * RotationAmount);
    }
}
