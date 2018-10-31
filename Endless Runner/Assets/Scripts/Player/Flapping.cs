using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flapping : MonoBehaviour {

    public float FlapTime = 0.25f;
    public float Force = 1.25f;

    private Rigidbody2D rb;
    private float forceMul = 1;

    void Start () {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(DoFlap());
    }

    void FixedUpdate () {
        rb.AddForce(Vector2.up * Physics2D.gravity * Force * forceMul);

        forceMul -= FlapTime;
    }

    IEnumerator DoFlap () {
        while (true) {
            forceMul = 1;

            yield return new WaitForSeconds(FlapTime);
        }
    }
}
