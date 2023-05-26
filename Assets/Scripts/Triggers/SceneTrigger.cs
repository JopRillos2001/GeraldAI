using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private SceneEnum scene;
    private SceneHandler sceneHandler;
    private GameObject player;

    private void Start() {
        sceneHandler = GameManager.Instance.GetComponent<SceneHandler>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            sceneHandler.SceneLoad(scene);
        }
    }
}
