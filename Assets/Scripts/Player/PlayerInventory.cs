using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfDirt { get; private set; }

    public UnityEvent<PlayerInventory> OnDirtCollected;
    

    public void DirtCollected()
    {
        NumberOfDirt++;
        OnDirtCollected.Invoke(this);
    }
}
