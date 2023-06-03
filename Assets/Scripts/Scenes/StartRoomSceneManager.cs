using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartRoomSceneManager : MonoBehaviour
{
    private GameObject player;
    private static StartRoomSceneManager _instance;
    public TMP_Text countText;
    public int startCount;
    private int count;

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

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<StarterAssets.GeraldInputs>().offMoveTotal();
    }
    
}
