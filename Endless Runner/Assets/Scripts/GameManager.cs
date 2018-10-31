using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float MovementSpeed = 2f;
    public float DistanceTravelled = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DistanceTravelled += MovementSpeed * Time.deltaTime;
    }
}
