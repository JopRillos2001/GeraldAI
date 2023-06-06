using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI dirtText;

    // Start is called before the first frame update
    void Start()
    {
        dirtText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDirtText(PlayerInventory playerInventory)
    {
        dirtText.text = playerInventory.NumberOfDirt.ToString();
    }
}
