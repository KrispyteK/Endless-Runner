using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrag : MonoBehaviour {
    public float SideWaysDrag = 0.5f;

    private Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate () {
        rb.AddForce(-rb.velocity * new Vector2(SideWaysDrag, 0));
	}
}
