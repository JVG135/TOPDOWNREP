using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject playerclass;
    public GameObject ui;
    public GameObject spawn;
    public GameObject panel;

    public void Startgame()
    {
        playerclass.SetActive(true);
        ui.SetActive(false);
        spawn.SetActive(true);
        panel.SetActive(false);
    }
}
