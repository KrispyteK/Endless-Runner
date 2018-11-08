using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHive : MonoBehaviour {

    public GameObject Bees;

    private GameManager gameManager;

    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            gameObject.layer = LayerMask.NameToLayer("CollideWithGround");

            var bees = Instantiate(Bees, transform.position, Quaternion.Euler(0,0,0));
            bees.transform.position = transform.position;

            Destroy(GetComponent<DistanceJoint2D>());
        
            gameManager.MoveBack(4);
        }
    }
}
