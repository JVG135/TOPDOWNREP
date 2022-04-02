using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherUI : MonoBehaviour
{
    public GameObject target;
    public GameObject ach2;
    // Start is called before the first frame update
    private void Start()
    {

    }
    private void Update()
    {
        if (target.gameObject == null)
        {
            ach2.SetActive(true);
            Destroy(ach2.gameObject, 5f);
        }

    }
    private void OnDestroy()
    {
        //target.SetActive(true);
        //Destroy(target.gameObject, 5f);
    }

    public void kill()
    {
        if (ach2 != null)
        {
            ach2.SetActive(true);
            Destroy(ach2.gameObject, 5f);
        }
    }
}
