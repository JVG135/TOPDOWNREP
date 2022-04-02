using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;

    // Update is called once per frame
    void Update()
    {
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
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
