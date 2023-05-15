using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{

    private static int isTurnOn;
    private static int birdStyle;
    public static Option instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    public void SlectBird()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Play1()
    {
        birdStyle = 1;
        SceneManager.LoadSceneAsync(1);
    }
    public void Play2()
    {
        birdStyle = 2;
        SceneManager.LoadSceneAsync(1);
    }
    public void Play3()
    {
        birdStyle = 3;
        SceneManager.LoadSceneAsync(1);
    }
    public static int GetBird()
    {
        return birdStyle;
    }
    public static int GetIsTurnOn()
    {
        return isTurnOn;
    }
}
