using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AdSceneHandler : MonoBehaviour
{
    [SerializeField] private Animator lightAnimator;
    [SerializeField] private float delay = 13f;
    [SerializeField] private AICharacterControl botCleanAI;
    [SerializeField] private float bcDelay = 25f;
    [SerializeField] private SceneEnum nextScene;
    [SerializeField] private float sceneDelay = 48f;
    [SerializeField] private float mouseLockDelay = 46f;
    [SerializeField] private List<VirCamStamp> virCamsStamps;
    [SerializeField] private Button skipButton;

    private void Start() {
        Invoke("DimLight", delay);
        Invoke("EnAI", bcDelay);
        Invoke("NextScene", sceneDelay);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        foreach (VirCamStamp vcs in virCamsStamps) {
            StartCoroutine(SwitchCam(vcs.virCam, vcs.delay));
        }
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
        MouseLock();
        GameManager.Instance.GetComponent<SceneHandler>().SceneLoad(nextScene);
    }

    private void disableAllVirCams() {
        foreach (VirCamStamp vcs in virCamsStamps) {
            vcs.virCam.SetActive(false);
        }
    }

    private void MouseLock() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void disableButton() {
        skipButton.interactable = false;
    }
}
