using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingMovement : MonoBehaviour {

    public GameObject Parent;
    public float SpringForce = 100f;
    public float SpringDamping = 0.1f;
    public float FlapTime = 0.1f;
    public float FlapForce = 100f;
    public float FlapUpwardForce = 100f;
    public float RotationForce = 50f;
    public KeyCode InputKey;

    private Rigidbody2D parentRB;
    private Rigidbody2D rb;
    private bool isFlapping;
    private float flapMultiplier;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        parentRB = Parent.GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate () {
        MoveWingToDefaultPosition();
    }

    void Update () {
        if (Input.GetKeyDown(InputKey)) {
            FlapWing();
        }
    }

    void MoveWingToDefaultPosition () {
        var currentAngle = transform.localRotation;

        rb.AddTorque(-currentAngle.z * SpringForce - rb.angularVelocity * SpringDamping);
    }

    void FlapWing () {
        if (!isFlapping) {
            isFlapping = true;
            flapMultiplier = 1f;

            StartCoroutine("FlapMovement");
        }
    }

    IEnumerator FlapMovement () {
        while (isFlapping) {
            rb.AddTorque(flapMultiplier * FlapForce * Time.deltaTime);

            if (flapMultiplier > 0.75f) {
                parentRB.AddForce(Parent.transform.up * FlapUpwardForce * flapMultiplier * Time.deltaTime);
                parentRB.AddTorque(flapMultiplier * -RotationForce * Time.deltaTime);
            }

            flapMultiplier -= (1/FlapTime) * Time.deltaTime;

            if (flapMultiplier > 0) {
                yield return null;
            } else {
                isFlapping = false;
                break;
            }
        }
    }
}
