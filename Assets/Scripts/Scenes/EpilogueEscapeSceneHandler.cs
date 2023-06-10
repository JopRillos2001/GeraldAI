using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpilogueEscapeSceneHandler : MonoBehaviour
{
    [SerializeField] private SceneEnum nextScene;
    [SerializeField] private float sceneDelay;
    [SerializeField] private Animator blocker;
    [SerializeField] private List<VirCamStamp> virCamsStamps;

    private void Start() {
        Invoke("NextScene", sceneDelay);

        foreach (VirCamStamp vcs in virCamsStamps) {
            StartCoroutine(SwitchCam(vcs.virCam, vcs.delay, vcs.fadedTransition));
        }
    }

    private IEnumerator SwitchCam(GameObject virCam, float delay, bool faded) {
        yield return new WaitForSeconds(delay);
        if (faded) {
            blocker.SetBool("Blocked", true);
            yield return new WaitForSeconds(2);
            blocker.SetBool("Blocked", false);
        }
        disableAllVirCams();
        virCam.SetActive(true);
    }

    private void NextScene() {
        GameManager.Instance.GetComponent<SceneHandler>().SceneLoad(nextScene);
    }

    private void disableAllVirCams() {
        foreach (VirCamStamp vcs in virCamsStamps) {
            vcs.virCam.SetActive(false);
        }
    }
}
