using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panner : MonoBehaviour {

    public float Speed = 1f;
    public GameObject Left;
    public GameObject Right;

    private float width = 0;
    private GameManager gameManager;

	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        width = Left.GetComponent<Renderer>().bounds.size.x;
    }
	
	void Update () {
        Left.transform.localPosition = new Vector2(Mathf.Floor(gameManager.DistanceTravelled / width) * width, 0);
        Right.transform.localPosition = new Vector2(Mathf.Floor(gameManager.DistanceTravelled / width + 1) * width, 0);
    }
}
