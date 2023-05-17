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

    public Animator animator;

    [SerializeField] private GameObject bird;
    [SerializeField] private GameManager gameManager;

    public GameObject pipe;
    public bool passScore = false;
    private bool startPanel = false;
    public static Bird instance;

    [SerializeField] private Canvas gameOver;
    [SerializeField] private Image bullet;
    [SerializeField] private Image slow;
    [SerializeField] private Image flash;

    public Image imageCoolDown;
    public float cdTime = 1.0f;
    public bool isCoolDown = false;

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
            flash.gameObject.SetActive(true);
        }
        if (Option.GetBird() == 2)
        {
            slow.gameObject.SetActive(false);
            bullet.gameObject.SetActive(true);
            flash.gameObject.SetActive(false);
        }
        if (Option.GetBird() == 3)
        {
            slow.gameObject.SetActive(true);
            bullet.gameObject.SetActive(false);
            flash.gameObject.SetActive(false);
        }
    }

    public virtual void Start()
    {
        animator = GetComponent<Animator>();
        if (!startPanel)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
    }

    public virtual void Update()
    {
        if (BirdController.birdActive == BirdController.SetActive.Dead)
        {
            return;
        }
        birdMove();
        CheckCollision();
        Flash();
    }

    public void birdMove()
    {
        if(BirdController.birdActive == BirdController.SetActive.Dead)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            startPanel = true;
            velocity = jumpForce;
            SoundManager.instance.PlaySound(jumpSound);
        }
        
        velocity += gravity * Time.deltaTime;

        transform.position += new Vector3(0, velocity, 0) * Time.deltaTime;
    }

    public void CheckCollision()
    {
        if (bird.transform.position.y < -3.75f)
        {
            BirdController.birdActive = BirdController.SetActive.Dead;
            gameOver.gameObject.SetActive(true);
            SoundManager.instance.PlaySound(gameOverSound);
            Time.timeScale = 0.0f;
        }

        if (pipe.transform.position.x <= -4.0f && pipe.transform.position.x >= -6.0f)
        {
            if (BirdController.birdActive == BirdController.SetActive.Alive)
            {
                if (isCoolDown)
                {
                    float flashDistance = 0.0f;
                    Vector3 currentPosition = transform.position;
                    Vector3 targetPosition = currentPosition + Vector3.right * flashDistance;
                    transform.position = targetPosition;
                    passScore = true;
                }
                else
                {
                    if (bird.transform.position.y >= pipe.transform.position.y + 1.3f || bird.transform.position.y <= pipe.transform.position.y - 1.2f)
                    {
                        BirdController.birdActive = BirdController.SetActive.Dead;
                        gameOver.gameObject.SetActive(true);
                        SoundManager.instance.PlaySound(gameOverSound);
                        Time.timeScale = 0.0f;
                    }
                    if (!passScore)
                    {
                        gameManager.IncreaseScore();
                        passScore = true;
                        SoundManager.instance.PlaySound(scoreSound);
                    }
                }
            }
        }

        if (pipe.transform.position.x <= -6.0f)
        {
            passScore = false;
        }
    }

    public void Flash()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isCoolDown = true;
        }

        if (isCoolDown && BirdController.birdActive == BirdController.SetActive.Alive)
        {
            Time.timeScale = 1f;

            imageCoolDown.fillAmount += 1 / cdTime * Time.deltaTime;
            if (imageCoolDown.fillAmount >= 1)
            {
                imageCoolDown.fillAmount = 0;

                Time.timeScale = 1f;
                isCoolDown = false;
            }
        }
    }
}