using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHiveSpawner : MonoBehaviour {

    public float MinDistance;
    public float MaxDistance;
    public DistanceJoint2D Joint;
    public GameObject Hive;

	void Start () {
        Joint.distance = Random.Range(MinDistance, MaxDistance);
        var direction = (Hive.transform.position - transform.position).normalized;

        Hive.transform.position = transform.position + direction * Joint.distance;
    }
}
