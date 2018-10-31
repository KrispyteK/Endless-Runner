using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float MovementSpeed = 2f;
    public float DistanceTravelled = 0f;

    public GUIStyle GUIStyle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DistanceTravelled += MovementSpeed * Time.deltaTime;
    }

    void OnGUI() {
        GUI.Label(new Rect(Screen.width - 300, 100, 0, 0), "DISTANCE: " + DistanceTravelled.ToString("F2"), GUIStyle);
    }
}
