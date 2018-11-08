using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormUpForce : MonoBehaviour {

    public float ForceScale = 1f;
    public float SideToSideMovement = 1f;
    public float SideToSideVariance = 1f;

    private Rigidbody2D rb;
    private float noiseOffsetX;
    private float noiseOffsetY;
    private Vector2 startPosition; 

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

	void Update () {
        noiseOffsetX += Time.deltaTime * SideToSideVariance;
        noiseOffsetY += Time.deltaTime * SideToSideVariance;

        var targetPosition = startPosition + new Vector2((0.5f - Mathf.PerlinNoise(noiseOffsetX, noiseOffsetY)) * 2 * SideToSideMovement, 0);
        var delta = targetPosition - (Vector2)transform.position;

        rb.AddForce(delta * ForceScale);
    }
}
