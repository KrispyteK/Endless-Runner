using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHive : MonoBehaviour {

    public GameObject Bees;

    private GameManager gameManager;
    private bool collided;
    private float affectedDistance;

    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            collided = true;

            StartCoroutine(affectDistanceTravelled());
            Destroy(GetComponent<Collider2D>());

            var bees = Instantiate(Bees, transform.position, Quaternion.Euler(0,0,0));
            bees.transform.position = transform.position;

            Destroy(GetComponent<DistanceJoint2D>());
        }
    }

    IEnumerator affectDistanceTravelled () {
        while (affectedDistance < 4f) {
            var change = Time.deltaTime * 4f;

            affectedDistance += change;
            gameManager.HitDistance += change;
            yield return null;
        }
    }
}
