using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{   
    public void Exit()
    {
        Application.Quit(); //close game (works in final build, but not editor?)
    }
}
