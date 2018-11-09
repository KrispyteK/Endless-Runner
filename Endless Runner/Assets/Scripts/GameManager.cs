using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float MovementSpeed = 2f;
    public float RecoverSpeed = 0.1f;

    public ObstacleSpawner ObstacleSpawner;

    [HideInInspector] public float DistanceTravelled = 0f;
    [HideInInspector] public float HitDistance = 0f;
    [HideInInspector] public bool WasHit = false;
    [HideInInspector] public bool GameStarted = false;
    [HideInInspector] public bool IsDead = false;

    public GUIStyle GUIStyle;

    void Update() {

        if (Input.anyKey) {
            if (!GameStarted) {
                GameStarted = true;

                ObstacleSpawner.SpawnObstacles();
            } else if (GameStarted && IsDead) {
                SceneManager.LoadScene("MainLevel");
            }
        }

        if (GameStarted && !IsDead) {
            DistanceTravelled += MovementSpeed * Time.deltaTime;

            if (HitDistance > 0) {
                HitDistance = Mathf.Clamp(HitDistance - RecoverSpeed * Time.deltaTime, 0, Mathf.Infinity);

                if (HitDistance > (Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - DistanceTravelled)) {
                    IsDead = true;

                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                }
            }
        }
    }

    void OnGUI() {
        if (GameStarted) {
            GUI.Label(new Rect(Screen.width - 300,200, 0, 0), "SCORE: " + Mathf.Floor(DistanceTravelled), GUIStyle);

            if (IsDead) {
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 0, 0), "GAME OVER", GUIStyle);
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + 200, 0, 0), "PRESS ANY KEY TO RESTART", GUIStyle);
            }
        } else {
            GUI.Label(new Rect(Screen.width/2, Screen.height / 2 + 200, 0, 0), "PRESS ANY KEY TO START", GUIStyle);

            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 - 300, 0, 0), "PRESS UP OR DOWN TO CONTROL BUBBA!", GUIStyle);
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 - 250, 0, 0), "HITTING AN OBSTACLE MAKES YOU GO BACKWARDS", GUIStyle);
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 - 200, 0, 0), "HIT THE BEES AND ITS GAMEOVER!", GUIStyle);
        }
    }

    public void MoveBack(float distance) {
        if (!WasHit) {
            WasHit = true;

            StartCoroutine(affectDistanceTravelled(distance));
        }
    }

    IEnumerator affectDistanceTravelled(float distance) {
        float affectedDistance = 0f;

        while (affectedDistance < distance) {
            var change = Time.deltaTime * distance;

            affectedDistance += change;
            HitDistance += change;
            yield return null;
        }

        WasHit = false;
    }
}
