using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameManager gameManager;

    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update () {
        transform.position = new Vector3(gameManager.DistanceTravelled, 0, -10);
    }
}
