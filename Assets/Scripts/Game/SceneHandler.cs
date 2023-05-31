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

    private void load() {
        StopAllCoroutines();
        SceneManager.LoadScene(scenes.Where(r => r.scene == sceneToLoad).First().sceneId);
        GameManager.Instance.GetComponent<ProgressManager>().currentScene = sceneToLoad;
    }

    public SceneEnum getCurrentScene() {
        int sceneID = SceneManager.GetActiveScene().buildIndex;
        return scenes.Where(r => r.sceneId == sceneID).First().scene;
    }
}
