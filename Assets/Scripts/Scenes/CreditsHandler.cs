using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsHandler : MonoBehaviour
{
    [SerializeField] private SceneEnum nextScene;
    [SerializeField] private float sceneDelay;

    private void Start() {
        Invoke("NextScene", sceneDelay);
    }

    private void NextScene() {
        GameManager.Instance.GetComponent<SceneHandler>().SceneLoad(nextScene);
    }
}
