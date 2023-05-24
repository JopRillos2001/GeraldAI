using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoomSceneManager : MonoBehaviour
{
    private static StartRoomSceneManager _instance;

    public static StartRoomSceneManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
