using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfDirt { get; private set; }

    public void DirtCollected()
    {
        NumberOfDirt++;
    }
}
