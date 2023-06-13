using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderNum : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text numText;
    private GeraldController geraldController;

    private void Start() {
        geraldController = GameObject.FindGameObjectWithTag("Player").GetComponent<GeraldController>();
        slider.value = GameManager.Instance.GetComponent<ProgressManager>().RotationSpeed;
    }

    private void Update() {
        numText.text = slider.value.ToString("0.#");
        GameManager.Instance.GetComponent<ProgressManager>().RotationSpeed = slider.value;
    }
}
