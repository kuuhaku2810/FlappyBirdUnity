using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Canvas pauseGame;
    // Start is called before the first frame update
    void Start()
    {
        pauseGame.gameObject.SetActive(false);
    }

    // Update is called once per frame
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
                pauseGame.gameObject.SetActive(true);
                BirdController.birdActive = BirdController.SetActive.Dead;
                Time.timeScale = 0;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                pauseGame.gameObject.SetActive(false);
                BirdController.birdActive = BirdController.SetActive.Alive;
                Time.timeScale = 1;
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
    }
    public void Remuse()
    {
        pauseGame.gameObject.SetActive(false);
        BirdController.birdActive = BirdController.SetActive.Alive;
    }
    public void GoHome()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Replay()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
