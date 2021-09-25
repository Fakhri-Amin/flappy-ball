using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public TextMeshProUGUI scoreText;
    public GameObject touchText;

    public GameObject gameOverScene;
    public GameObject scoreCanvas;
    public GameObject explodeEffect;

    [Header("Music And Sound")]
    public AudioClip jumpSound;
    [Range(0, 1)] public float soundVolume = 0.75f;
    public GameObject gameMusic;
    public GameObject gameOverSound;

    private Rigidbody2D rb;
    private float score;
    public bool gameHasStarted = false;
    public GameObject particleBG;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        particleBG.GetComponent<Block>().enabled = false;
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameHasStarted == false)
        {
            gameHasStarted = true;
            rb.gravityScale = 4.5f;
            particleBG.GetComponent<Block>().enabled = true;
            touchText.gameObject.SetActive(false);
            gameMusic.SetActive(true);
        }

        if (gameHasStarted)
        {
            scoreText.text = score.ToString();
            FindObjectOfType<ScoreText>().ResultScore(score);
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.up * jumpForce;
                AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position, soundVolume);
            }

            if (transform.position.y < -9 || transform.position.y > 9)
            {
                Die();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreTrigger"))
        {
            score++;
        }

        if (other.gameObject.CompareTag("Block"))
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(explodeEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        FindObjectOfType<Spawner>().gameObject.SetActive(false);
        gameOverScene.SetActive(true);
        scoreCanvas.SetActive(false);
        gameMusic.SetActive(false);
        gameOverSound.SetActive(true);
    }

}
