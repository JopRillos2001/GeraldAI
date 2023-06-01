using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidHandler : MonoBehaviour
{
    private GameObject player;
    private bool ripperoni;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        if (player.transform.position.y < -200 && !ripperoni) {
            ripperoni = true;
            GameManager.Instance.GetComponent<SceneHandler>().SceneLoad(GameManager.Instance.GetComponent<SceneHandler>().getCurrentScene());
        }
    }
}
