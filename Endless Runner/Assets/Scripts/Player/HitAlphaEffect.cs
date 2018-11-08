using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAlphaEffect : MonoBehaviour {

    private Color startColor;
    private SpriteRenderer sprite;
    private GameManager gameManager;

    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        startColor = sprite.color;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

	void Update () {
		if (gameManager.WasHit) {
            var newColor = (Mathf.Floor(Time.realtimeSinceStartup * 4) % 2) == 0 ? startColor * new Color(1, 0.25f, 0.25f, 0.75f) : startColor;

            sprite.color = newColor;
        } else if (sprite.color != startColor) {
            sprite.color = startColor;
        }
	}
}
