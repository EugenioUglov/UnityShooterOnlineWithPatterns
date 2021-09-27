using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineGame : MonoBehaviour
{
    [SerializeField] 
    private GameObject _networkMenu;

    public void StartOnlineGame()
    {
        print("Start online game");
        _networkMenu.SetActive(true);
    }
}
