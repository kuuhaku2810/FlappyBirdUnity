using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float jumpForce;
    public float gravity;
    float velocity;

    [SerializeField] private GameObject bird;

    public Animator animator;

    [SerializeField] private GameManager gameManager;

    public GameObject pipe;
    public bool passScore = false;
    public static Bird instance;

    [SerializeField] private Canvas gameOver;
    [SerializeField] private Image bullet;
    [SerializeField] private Image slow;

    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    public AudioClip scoreSound;

    public virtual void Awake()
    {
        instance = this;
        gameOver.gameObject.SetActive(false);

        if (Option.GetBird() == 1 || Option.GetBird() == 0)
        {
            bullet.gameObject.SetActive(false);
            slow.gameObject.SetActive(false);
        }
        if (Option.GetBird() == 2)
        {
            slow.gameObject.SetActive(false);
            bullet.gameObject.SetActive(true);
        }
        if (Option.GetBird() == 3)
        {
            slow.gameObject.SetActive(true);
            bullet.gameObject.SetActive(false);
        }
    }

    public virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        if (BirdController.birdActive == BirdController.SetActive.Dead)
        {
            return;
        }
        birdMove();
        CheckCollision();
    }

    public void birdMove()
    {
        if(BirdController.birdActive == BirdController.SetActive.Dead)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            velocity = jumpForce;
            SoundManager.instance.PlaySound(jumpSound);
        }

        velocity += gravity * Time.deltaTime;

        transform.position += new Vector3(0, velocity, 0) * Time.deltaTime;
    }

    public void CheckCollision()
    {
        if (bird.transform.position.y < -3.75)
        {
            BirdController.birdActive = BirdController.SetActive.Dead;
            gameOver.gameObject.SetActive(true);
            SoundManager.instance.PlaySound(gameOverSound);
            Time.timeScale = 0;
        }

        if (pipe.transform.position.x <= -4f && pipe.transform.position.x >= -6f)
        {

            if (bird.transform.position.y >= pipe.transform.position.y + 1.3f || bird.transform.position.y <= pipe.transform.position.y - 1.2f)
            {
                BirdController.birdActive = BirdController.SetActive.Dead;
                gameOver.gameObject.SetActive(true);
                SoundManager.instance.PlaySound(gameOverSound);
                Time.timeScale = 0;
            }
            if (!passScore)
            {
                gameManager.IncreaseScore();
                passScore = true;
                SoundManager.instance.PlaySound(scoreSound);
            }
        }
        if (pipe.transform.position.x <= -6f)
        {
            passScore = false;
        }
    }
}