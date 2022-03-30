using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;//PLAYER HEALTH, DIFF BETWEEN CLASSES
    [SerializeField] private TextMeshProUGUI lifeText;
    public GameObject endpan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = " Health: " + health;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                lifeText.text = " DEAD";
                endpan.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
