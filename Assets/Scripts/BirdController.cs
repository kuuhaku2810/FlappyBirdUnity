using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public enum SetActive
    {
        Alive,
        Dead
    }
    public static SetActive birdActive;


    [SerializeField] private GameObject FlappyBird1;
    [SerializeField] private GameObject FlappyBird2;
    [SerializeField] private GameObject FlappyBird3;

    private int activeNum;
    private int birdStyle;



    private void Awake()
    {
        birdActive = SetActive.Dead;
        birdStyle = Option.GetBird();
        activeNum = 0;
        if (birdStyle == 0)
        {
            FlappyBird2.SetActive(false);
            FlappyBird3.SetActive(false);
        }
        if (birdStyle == 1)
        {
            FlappyBird2.SetActive(false);
            FlappyBird3.SetActive(false);
        }
        if (birdStyle == 2)
        {
            FlappyBird1.SetActive(false);
            FlappyBird3.SetActive(false);
        }
        if (birdStyle == 3)
        {
            FlappyBird1.SetActive(false);
            FlappyBird2.SetActive(false);
        }

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && activeNum == 0)
        {
            Time.timeScale = 1.0f;
            birdActive = SetActive.Alive;
            activeNum++;
        }

    }
}
