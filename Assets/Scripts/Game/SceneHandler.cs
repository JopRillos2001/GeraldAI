using System;
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

    public void SceneLoad(SceneEnum scene) {
        blockerAnimator = GameObject.FindGameObjectWithTag("BlockerPanel").GetComponent<Animator>();
        sceneToLoad = scene;
        blockerAnimator.SetBool("Blocked", true);
        Invoke("load", 2);
    }

    public void QuitGame() {
        blockerAnimator = GameObject.FindGameObjectWithTag("BlockerPanel").GetComponent<Animator>();
        blockerAnimator.SetBool("Blocked", true);
        Invoke("quit", 2);
    }

    private void load() {
        StopAllCoroutines();
        SceneManager.LoadScene(scenes.Where(r => r.scene == sceneToLoad).First().sceneId);
        GameManager.Instance.GetComponent<ProgressManager>().previousScene = GameManager.Instance.GetComponent<ProgressManager>().currentScene;
        if (scenes.Where(r => r.scene == sceneToLoad).First().inGame) {
            GameManager.Instance.GetComponent<ProgressManager>().currentScene = sceneToLoad;
        }
    }

    private void quit() {
        StopAllCoroutines();
        Application.Quit();
    }

    public SceneEnum getCurrentScene() {
        int sceneID = SceneManager.GetActiveScene().buildIndex;
        return scenes.Where(r => r.sceneId == sceneID).First().scene;
    }
}
