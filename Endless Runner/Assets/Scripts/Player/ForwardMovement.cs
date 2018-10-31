using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour {

    public float Speed = 1;

    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

	void Update () {
        rb.velocity = new Vector2(Speed,rb.velocity.y);
	}
}
