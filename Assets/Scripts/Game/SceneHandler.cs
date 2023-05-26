using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public List<SceneClass> scenes;
    private SceneEnum sceneToLoad;
    private Animator blockerAnimator;

    private void Start() {
        blockerAnimator = GameObject.FindGameObjectWithTag("BlockerPanel").GetComponent<Animator>();
    }

    public void SceneLoad(SceneEnum scene) {
        sceneToLoad = scene;
        blockerAnimator.SetBool("Blocked", true);
        Invoke("load", 2);
    }

    private void load() {
        SceneManager.LoadScene(scenes.Where(r => r.scene == sceneToLoad).First().sceneId);
    }
}
