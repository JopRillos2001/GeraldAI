using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollectableCheckClass
{
    public List<ItemTrigger> itemTriggers;
    public Animator animator;
    public string attributeName;
    public AudioClip audioClip;
    public bool completed;
}
