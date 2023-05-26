using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScene1Manager : MonoBehaviour
{
    private GameObject player;
    private static PuzzleScene1Manager _instance;

    public static PuzzleScene1Manager Instance {
        get { return _instance; }
    }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private void Start() {

        player = GameObject.FindGameObjectWithTag("Player");
    }
}
