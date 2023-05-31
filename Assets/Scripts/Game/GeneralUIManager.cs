using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneralUIManager : MonoBehaviour
{
    [SerializeField] private Transform mechanicsContent;
    [SerializeField] private GameObject mechanicsItem;
    [SerializeField] private GameObject pausePanel;
    public bool menuOpen = false;
    private GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        hideMenu();
    }

    public void updateMechanicsView() {
        List<MechanicClass> mechanicItems = GameManager.Instance.GetComponent<ProgressManager>().mechanics.Where(r => r.discovered == true).OrderBy(r => r.discoverOrder).ToList();
        foreach (Transform item in mechanicsContent) {
            Destroy(item.gameObject);
        }
        foreach (MechanicClass mechanicItem in mechanicItems) {
            GameObject obj = Instantiate(mechanicsItem, mechanicsContent);

            TMP_Text mechanicItemName = obj.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
            TMP_Text mechanicItemDesc = obj.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>();

            mechanicItemName.text = mechanicItem.mechanicName;
            mechanicItemDesc.text = mechanicItem.mechanicDesc;
        }
    }

    public void ToggleMenu() {
        menuOpen = !menuOpen;
        if (menuOpen) {
            updateMechanicsView();
            showMenu();            
        } else {
            hideMenu();
        }
    }

    private void hideMenu() {
        pausePanel.GetComponent<Animator>().SetBool("Paused", false);
        player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorInputForLook = true;
        player.GetComponent<StarterAssets.StarterAssetsInputs>().onMove();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void showMenu() {
        pausePanel.GetComponent<Animator>().SetBool("Paused", true);
        player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorInputForLook = false;
        player.GetComponent<StarterAssets.StarterAssetsInputs>().offMove();
        player.GetComponent<StarterAssets.StarterAssetsInputs>().stopMoving();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ClickSceneButton() {
        GameObject selected = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        if (selected.GetComponent<SceneButton>() != null) {
            SceneButton sceneButton = selected.GetComponent<SceneButton>();
            GameManager.Instance.GetComponent<SceneHandler>().SceneLoad(sceneButton.buttonScene);
        } else {
            Debug.LogError("Component 'SceneButton', which is required for this function, is missing");
        }      
    }

    public void ClickRestartButton() {
        GameManager.Instance.GetComponent<SceneHandler>().SceneLoad(GameManager.Instance.GetComponent<SceneHandler>().getCurrentScene());
    }

    public void ClickContinueButton() {
        ToggleMenu();
    }
}
