using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    public Vector2 moveDirect;
    public Vector2 player;
    public Transform target;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        player = target.position;
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = rotation;//speed of rotate

        //movement towards last player position
        rb = GetComponent<Rigidbody2D>();
        moveDirect = (direction).normalized * speed;
        rb.velocity = new Vector2(moveDirect.x, moveDirect.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    public void DeleteEnemy ()
    {
        Destroy(gameObject);
    }
}
