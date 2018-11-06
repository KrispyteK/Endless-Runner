using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float MovementSpeed = 2f;
    public float RecoverSpeed = 0.1f;
    [HideInInspector] public float DistanceTravelled = 0f;
    [HideInInspector] public float HitDistance = 0f;

    public GUIStyle GUIStyle;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        DistanceTravelled += MovementSpeed * Time.deltaTime;

        if (HitDistance > 0) {
            HitDistance = Mathf.Clamp(HitDistance - RecoverSpeed * Time.deltaTime, 0, Mathf.Infinity);
        }
    }

    void OnGUI() {
        GUI.Label(new Rect(Screen.width - 300, 100, 0, 0), "SCORE: " + Mathf.Floor(DistanceTravelled), GUIStyle);
    }
}
