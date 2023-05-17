using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Canvas pauseGame;
    private BackgroundMusic backgroundMusic;

    void Start()
    {
        pauseGame.gameObject.SetActive(false);
        backgroundMusic = FindObjectOfType<BackgroundMusic>();
    }

    void Update()
    {
        if (BirdController.birdActive == BirdController.SetActive.Dead)
        {
            return;
        }

        if (BirdController.birdActive == BirdController.SetActive.Alive)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Pause();
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        if (BirdController.birdActive == BirdController.SetActive.Dead)
        {
            return;
        }
        pauseGame.gameObject.SetActive(true);
        BirdController.birdActive = BirdController.SetActive.Dead;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseGame.gameObject.SetActive(false);
        BirdController.birdActive = BirdController.SetActive.Alive;
        Time.timeScale = 1;
    }

    public void GoHome()
    {
        SceneManager.LoadScene("StartMenu");

        if (backgroundMusic != null)
        {
            Destroy(backgroundMusic.gameObject);
        }
    }

    public void Replay()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.PlayMusic();
        }
        SceneManager.LoadScene("MainMenu");
    }
}
