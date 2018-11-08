using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject World;
    public Obstacle[] Obstacles;

    [System.Serializable]
    public struct Obstacle {
        public GameObject Object;
        public float SpawnFrequency;
        public float FrequencyVariance;
        public float GameStartSpawnDelay;
        public float SideToSideVariance;
        public bool SpawnAtStart;
        public int SpawnAtStartAmount;
        public float MinHeight;
        public float MaxHeight;
        public float MinScale;
        public float MaxScale;
    }

	void Start () {
        foreach (var o in Obstacles) {
            StartCoroutine(SpawnObstacleBasedOnTime(o));
        }
    }

    IEnumerator SpawnObstacleBasedOnTime (Obstacle obstacle) {
        yield return new WaitForSeconds(obstacle.GameStartSpawnDelay);

        if (obstacle.SpawnAtStart) {
            for (int i = 0; i < obstacle.SpawnAtStartAmount; i++) {
                var spawned = Instantiate(
                        obstacle.Object, 
                        new Vector2(Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(-1f,1.5f), Random.Range(obstacle.MinHeight, obstacle.MaxHeight), 0)).x, 0), 
                        Quaternion.Euler(0, 0, 0)
                    );

                spawned.transform.parent = World.transform;
            }
        }

        while(true) {
            var spawned = Instantiate(
                obstacle.Object, 
                Vector2.zero, 
                Quaternion.Euler(0,0,0)
                );

            spawned.transform.position = new Vector2(
                    Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + Random.Range(0f, obstacle.SideToSideVariance),
                    Random.Range(obstacle.MinHeight, obstacle.MaxHeight)
                );
            spawned.transform.parent = World.transform;
            spawned.transform.localScale *= Random.Range(obstacle.MinScale, obstacle.MaxScale);

            yield return new WaitForSeconds(obstacle.SpawnFrequency + Random.Range(-obstacle.FrequencyVariance, obstacle.FrequencyVariance));
        }
    }
}
