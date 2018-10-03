using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject Player;
    public Obstacle[] Obstacles;
    public float SpawnRate;
    
    [System.Serializable]
    public class Obstacle {
        public GameObject Object;
        public float MinHeight;
        public float MaxHeight;
        public float Chance;
    }
	
    void Start () {
        StartCoroutine("SpawnObjects");
    }

    IEnumerator SpawnObjects () {
        while (true) {
            var obstacle = ChooseObstacle();

            if (obstacle != null) {
                var spawnPosition = Player.transform.position + new Vector3((Random.Range(0f,1f) * Camera.main.orthographicSize - Camera.main.orthographicSize/2) * 2f, Camera.main.orthographicSize, 0);
                var hit = Physics2D.CircleCast(spawnPosition, 2f, Vector3.zero);

                if (hit.collider == null) {
                    Instantiate(obstacle.Object, spawnPosition, Quaternion.Euler(0, 0, 0));
                }
            }

            yield return new WaitForSeconds(SpawnRate);
        }
    }

    Obstacle ChooseObstacle () {
        var height = Player.transform.position.y;
        var comparer = Random.Range(0f,1f);
        var highestChance = 0.0f;
        Obstacle result = null;
        Obstacle highestChanceObstacle = null;

        foreach (var o in Obstacles) {
            if (height < o.MinHeight || height > o.MaxHeight) continue;

            if (comparer < o.Chance) {
                result = o;
            }

            if (o.Chance > highestChance) {
                highestChance = o.Chance;
                highestChanceObstacle = o;
            }
        }

        return result ?? highestChanceObstacle;
    }
}
