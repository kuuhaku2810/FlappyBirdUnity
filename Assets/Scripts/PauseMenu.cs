using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private Canvas pauseGame;

    private void Start()
    {
        pauseGame.gameObject.SetActive(false);
    }


    public void Update()
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
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                pauseGame.gameObject.SetActive(false);
                BirdController.birdActive = BirdController.SetActive.Alive;
            }
        }

    }

    public void Replay()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void GoHome()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void GameOver()
    {
        Pause();
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
}