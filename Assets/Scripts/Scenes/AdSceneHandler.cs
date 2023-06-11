using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class AdSceneHandler : MonoBehaviour
{
    [SerializeField] private Animator lightAnimator;
    [SerializeField] private float delay = 13f;
    [SerializeField] private AICharacterControl botCleanAI;
    [SerializeField] private float bcDelay = 25f;
    [SerializeField] private SceneEnum nextScene;
    [SerializeField] private float sceneDelay = 48f;
    [SerializeField] private List<VirCamStamp> virCamsStamps;

    private void Start() {
        Invoke("DimLight", delay);
        Invoke("EnAI", bcDelay);
        Invoke("NextScene", sceneDelay);

        foreach (VirCamStamp vcs in virCamsStamps) {
            StartCoroutine(SwitchCam(vcs.virCam, vcs.delay));
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private IEnumerator SwitchCam(GameObject virCam, float delay) {
        yield return new WaitForSeconds(delay);
        disableAllVirCams();
        virCam.SetActive(true);
    }

    private void EnAI() {
        botCleanAI.disableAi = false;
    }

    private void DimLight() {
        lightAnimator.SetBool("Dim", true);
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
