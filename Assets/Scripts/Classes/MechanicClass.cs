using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MechanicClass
{
    public MechanicEnum mechanic;
    public string mechanicName;
    public string mechanicDesc;
    public bool discovered;
    public int discoverOrder = 0;
}
