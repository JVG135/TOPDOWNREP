using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class moverotation : MonoBehaviour
{//CODE FOR PLAYER
    private float move;
    private float rotation;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField]  private float rotationSpeed = 400f;
    [SerializeField] public Transform shootSpawn;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private int lives = 5;
    [SerializeField] private AudioClip bulletSFX;
    [SerializeField] private AudioClip hurtSFX;
    public GameObject BulletPrefab;
    public int score = 0;
    private float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        lifeText.text = "Lives: " + lives;

        move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;//move forward and back
        rotation = Input.GetAxis("Horizontal") * -rotationSpeed * Time.deltaTime;//rotate player

        if (Input.GetKeyDown("space"))
        {
            ShootBullets();
        }

        // screen bounds. If you want the min max values to update if the resolution changes 
        // set them in update else set them in Start
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;

        // Get current position
        Vector3 pos = transform.position;

        // Horizontal contraint
        if (pos.x < minX) pos.x = minX;
        if (pos.x > maxX) pos.x = maxX;

        // vertical contraint
        if (pos.y < minY) pos.y = minY;
        if (pos.y > maxY) pos.y = maxY;

        // Update position
        transform.position = pos;
    }

    void ShootBullets()
    {
        AudioSource audio = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        audio.PlayOneShot(bulletSFX, 0.5f);
        GameObject g = Instantiate(BulletPrefab, shootSpawn.position, Quaternion.identity);
        Bullet b = g.GetComponent<Bullet>();
        Vector2 direction = (shootSpawn.position - transform.position).normalized;
        b.direction = direction;

        Destroy(g, 1f); //disappear after x frames
    }

    private void LateUpdate()
    {
        transform.Translate(0f, move, 0f);
        transform.Rotate(0f, 0f, rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lives--;
            AudioSource audio = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
            audio.PlayOneShot(hurtSFX, 0.5f);
            Destroy(collision.gameObject);
            if (lives <= 0)
            {
                //gameOverPanel.SetActive(true);
                SceneManager.LoadScene("gameover");
                //SceneManager.LoadScene(0); <- this also works
            }
        }
    }
}
