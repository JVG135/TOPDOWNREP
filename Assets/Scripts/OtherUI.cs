using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherUI : MonoBehaviour
{
    public GameObject target;
    public GameObject ach2;

    public void kill()
    {
        if (ach2 != null)//check if achievement still exists to be active, otherwise do nothing
        {
            ach2.SetActive(true);
            Destroy(ach2.gameObject, 5f);
        }
    }
}
