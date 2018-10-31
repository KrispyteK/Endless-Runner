using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject World;
    public Obstacle[] Obstacles;

    private GameManager gameManager;

    [System.Serializable]
    public struct Obstacle {
        public GameObject Object;
        public float SpawnFrequency;
        public float FrequencyVariance;
        public float GameStartSpawnDelay;
        public float SideToSideVariance;
        public bool SpawnAtStart;
        public int SpawnAtStartAmount;
    }

	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        foreach (var o in Obstacles) {
            StartCoroutine(SpawnObstacleBasedOnTime(o));
        }
    }

    IEnumerator SpawnObstacleBasedOnTime (Obstacle obstacle) {
        yield return new WaitForSeconds(obstacle.GameStartSpawnDelay);

        if (obstacle.SpawnAtStart) {
            for (int i = 0; i < obstacle.SpawnAtStartAmount; i++) {
                var spawned = Instantiate(obstacle.Object, new Vector2(Random.Range(-1f, 1f) * Camera.main.orthographicSize * 4, 0), Quaternion.Euler(0, 0, 0));
                spawned.transform.parent = World.transform;
            }
        }

        while(true) {
            var spawned = Instantiate(obstacle.Object, new Vector2(gameManager.DistanceTravelled + Camera.main.orthographicSize * 6 + Random.Range(0f, obstacle.SideToSideVariance), 0), Quaternion.Euler(0,0,0));
            spawned.transform.parent = World.transform;

            yield return new WaitForSeconds(obstacle.SpawnFrequency + Random.Range(-obstacle.FrequencyVariance, obstacle.FrequencyVariance));
        }
    }
}
