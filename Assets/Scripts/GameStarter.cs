using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject playerclass;
    public GameObject ui;
    public GameObject spawn;
    public GameObject panel;
    public GameObject Achieve1;

    public void Startgame()
    {
        playerclass.SetActive(true);
        ui.SetActive(true);
        spawn.SetActive(true);
        panel.SetActive(false);
        Achieve1.SetActive(true);
        Destroy(Achieve1.gameObject,5f);
    }
}
