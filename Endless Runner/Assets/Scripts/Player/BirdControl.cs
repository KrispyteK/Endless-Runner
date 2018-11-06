using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour {

    public float Force = 1;

    private Rigidbody2D rb;
    private GameManager gameManager;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update () {
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * Force));

        var pos = transform.position;
        pos.x = gameManager.DistanceTravelled - gameManager.HitDistance;

        transform.position = pos;
    }
}
