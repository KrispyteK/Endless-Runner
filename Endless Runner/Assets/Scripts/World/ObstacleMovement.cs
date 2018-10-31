using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

    public float Speed = 1f;
    public GameObject Sprite;

    private GameManager gameManager;
    private float spriteWidth;
    private float startOffset;

    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        spriteWidth = Sprite.GetComponent<Renderer>().bounds.size.x;

        startOffset = transform.position.x + gameManager.DistanceTravelled;
    }
	
	void Update () {
        //transform.position = new Vector2((-(gameManager.DistanceTravelled - startOffset) * Speed), transform.position.y);

        if (transform.position.x < (-Camera.main.orthographicSize - spriteWidth + gameManager.DistanceTravelled)) {
            Destroy(gameObject);
        }
    }
}
