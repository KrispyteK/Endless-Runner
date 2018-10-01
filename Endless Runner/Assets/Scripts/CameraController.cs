using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Camera;
    public float CameraLag = 0.5f;
    
	void FixedUpdate () {
        Camera.transform.rotation = Quaternion.Euler(0,0,0);

        Camera.transform.position = Vector3.Lerp(Camera.transform.position, transform.position, CameraLag) + new Vector3(0,0,-10);
    }
}
