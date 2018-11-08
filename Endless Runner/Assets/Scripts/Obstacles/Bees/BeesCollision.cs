using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeesCollision : MonoBehaviour {
    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            Destroy(GetComponent<Collider2D>());
            Destroy(GetComponent<WormUpForce>());

            gameManager.MoveBack(4);
        }
    }
}
