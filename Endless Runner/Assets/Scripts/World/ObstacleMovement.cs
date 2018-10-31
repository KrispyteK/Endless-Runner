using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

    public float Speed = 1f;
    public GameObject Sprite;
    public float SpriteWidth;

    private GameManager gameManager;

    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SpriteWidth = Sprite.GetComponent<Renderer>().bounds.size.x;

        transform.position = transform.position + new Vector3(SpriteWidth, 0, 0);
    }
	
	void Update () {
        if (transform.position.x < (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - SpriteWidth)) {
            Destroy(gameObject);
        }
    }
}
