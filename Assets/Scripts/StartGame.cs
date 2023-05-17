using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;

    private void Start()
    {
        Time.timeScale = 0.0f;
        startPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            startPanel.SetActive(false);
            startGame();
        }
    }

    private void startGame()
    {
        Time.timeScale = 1.0f;
    }
}
