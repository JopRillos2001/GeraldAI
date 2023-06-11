using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButton : MonoBehaviour
{
    public SceneEnum buttonScene;

    public void LoadScene() {
        GameManager.Instance.GetComponent<SceneHandler>().SceneLoad(buttonScene);
    }
}
