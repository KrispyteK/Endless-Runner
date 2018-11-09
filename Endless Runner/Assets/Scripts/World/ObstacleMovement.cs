using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

    public float Speed = 0f;
    public bool SpawnWithOffset = true;
    public GameObject Sprite;


    [HideInInspector] public float SpriteWidth;
    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SpriteWidth = Sprite.GetComponent<Renderer>().bounds.size.x;

        if (SpawnWithOffset) {
            transform.position = transform.position + new Vector3(SpriteWidth, 0, 0);
        }
    }
	
	void Update () {
        if (!gameManager.IsDead && gameManager.GameStarted) {
            transform.position = transform.position + new Vector3(-Speed * Time.deltaTime, 0, 0);

            if (transform.position.x < (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - SpriteWidth)) {
                Destroy(gameObject);
            }
        }
    }
}
