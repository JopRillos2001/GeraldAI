using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsHandler : MonoBehaviour
{
    [SerializeField] private SceneEnum nextScene;
    [SerializeField] private float sceneDelay;
    [SerializeField] private List<GameObject> virCams;

    private void Start() {
        Invoke("NextScene", sceneDelay);
        startCam();
    }

    private void NextScene() {
        GameManager.Instance.GetComponent<SceneHandler>().SceneLoad(nextScene);
    }

    private void startCam() {
        disableAllCams();
        if (GameManager.Instance.GetComponent<ProgressManager>().previousScene == SceneEnum.EpilogueSaveScene) {
            virCams[0].SetActive(true);
        } else if (GameManager.Instance.GetComponent<ProgressManager>().previousScene == SceneEnum.EpilogueContinueScene) {
            virCams[1].SetActive(true);
        } else {
            virCams[2].SetActive(true);
        }
    }

    private void disableAllCams() {
        foreach (GameObject virCam in virCams) { 
            virCam.SetActive(false);
        }
    }
}
