using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class EpilogueContinueSceneHandler : MonoBehaviour
{
    [SerializeField] private SceneEnum nextScene;
    [SerializeField] private float sceneDelay;
    [SerializeField] private Animator blocker;
    [SerializeField] private List<VirCamStamp> virCamsStamps;
    [SerializeField] private List<AICharacterControl> preNpcs;
    [SerializeField] private float preNpcDelay;
    [SerializeField] private List<AICharacterControl> npcs;
    [SerializeField] private float npcDelay;

    private void Start() {
        Invoke("PreNPCDelay", preNpcDelay);
        Invoke("NPCDelay", npcDelay);
        Invoke("NextScene", sceneDelay);
        foreach (AICharacterControl npc in npcs) {
            npc.disableAi = true;
        }
        foreach (AICharacterControl npc in preNpcs) {
            npc.disableAi = true;
        }

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

    private void NPCDelay() {
        foreach (AICharacterControl npc in npcs) {
            npc.disableAi = false;
        }
    }

    private void PreNPCDelay() {
        foreach (AICharacterControl npc in preNpcs) {
            npc.disableAi = false;
        }
    }

    private void disableAllVirCams() {
        foreach (VirCamStamp vcs in virCamsStamps) {
            vcs.virCam.SetActive(false);
        }
    }
}
