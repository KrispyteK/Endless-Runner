using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : MonoBehaviour {

    public GameObject[] Sprites;

    private float[] offsets;
    private float x;

    void Start () {
        offsets = new float[Sprites.Length];

        for (int i = 0; i < Sprites.Length; i++) {
            offsets[i] = Sprites[i].transform.position.y;
        }
    }
	
	void Update () {
        x += Time.deltaTime;

        for (int i = 0; i < Sprites.Length; i++) {
            Sprites[i].transform.localPosition = new Vector2(
                (Mathf.PerlinNoise(x + offsets[i], x * 1.25f) * 2 - 1) / 2, 
                (Mathf.PerlinNoise(x - offsets[i], x * 0.5f) * 2 - 1) / 2
                ) * 1f + new Vector2(0,offsets[i]);
        }

        transform.position = new Vector2(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x,0);
    }
}
