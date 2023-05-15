using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird3 : Bird
{
    [SerializeField] private Image imageCoolDown;
    [SerializeField] private float cdTime = 3f;
    private bool isCoolDown = false;

    public override void Awake()
    {

    }

    public override void Start()
    {

    }

    public override void Update()
    {
        birdMove();
        CheckCollision();
        Slow();
    }

    public void Slow()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isCoolDown = true;
        }
        if (isCoolDown && BirdController.birdActive == BirdController.SetActive.Alive)
        {
            Time.timeScale = 0.4f;

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