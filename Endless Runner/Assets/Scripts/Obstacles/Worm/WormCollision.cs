using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormCollision : MonoBehaviour {

    private WormParent Parent;
    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Parent = transform.parent.GetComponent<WormParent>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            Destroy(GetComponent<HingeJoint2D>());
            Destroy(GetComponent<WormUpForce>());

            gameObject.layer = LayerMask.NameToLayer("CollideWithGround");

            foreach (var segment in Parent.Segments) {
                if (segment != gameObject) {
                    segment.layer = LayerMask.NameToLayer("CollideWithGround");

                    Destroy(segment.GetComponent<WormCollision>());
                    Destroy(segment.GetComponent<WormUpForce>());
                }
            }

            gameManager.MoveBack(4);
        }
    }
}
