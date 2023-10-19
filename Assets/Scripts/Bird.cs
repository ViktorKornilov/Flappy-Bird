using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float rotatePower;
    public float jumpSpeed;
    public TMP_Text scoreText;
    public GameObject endScreen;
    public GameObject flashEffect;

    public float speed;
    int score;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }


    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;
        PlayerPrefs.SetInt("Score",score);
        flashEffect.SetActive(true);

        Invoke("ShowMenu",1f);
    }

    void ShowMenu()
    {
        endScreen.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        score++;
        scoreText.text = score.ToString();
    }
}