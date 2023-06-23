using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableCountHandler : MonoBehaviour
{
    public TMP_Text countText;
    public ItemTrigger itemTrigger;

    private void Update() {
        countText.text = itemTrigger.getAmountInTrigger() + "/" + itemTrigger.getAmountNeeded();
    }
}
