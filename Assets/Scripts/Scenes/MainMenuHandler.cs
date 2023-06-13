using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    private ProgressManager progressManager;
    private SceneHandler sceneHandler;
    private void Start() {
        progressManager = GameManager.Instance.GetComponent<ProgressManager>();
        sceneHandler = GameManager.Instance.GetComponent<SceneHandler>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (progressManager.checkProgress())
        {
            continueButton.interactable = true;
        }
        else
        {
            continueButton.interactable = false;
        }
    }

    public void continueGame() {
        progressManager.loadProgress();
        sceneHandler.SceneLoad(progressManager.currentScene);
    }

    public void newGame()
    {
        progressManager.resetProgress();
        sceneHandler.SceneLoad(progressManager.defaultStartScene);
    }
}
