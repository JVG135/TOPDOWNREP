using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject[] UI;
    public Vector2 direction;
    //public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(direction * speed * Time.deltaTime);
        Destroy(gameObject,2f);
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            OtherUI a = GameObject.Find("achievement2control").GetComponent<OtherUI>();
            a.kill();
            Destroy(c.gameObject);
            Destroy(gameObject);
           // a.ach2.SetActive(true);
           // Destroy(a.ach2, 5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //UI = GameObject.FindGameObjectsWithTag("UI");
            // UI.SetActive(true);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
