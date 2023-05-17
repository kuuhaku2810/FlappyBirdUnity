using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird2 : Bird
{
    public AudioClip gunSound;

    public GameObject bulletPrefab;

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
        if (Option.GetBird() == 2)
        {
            Gun();
        }
    }

    public void Gun()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isCoolDown = true;
            SoundManager.instance.PlaySound(gunSound);
        }
        if (isCoolDown && BirdController.birdActive == BirdController.SetActive.Alive)
        {
            imageCoolDown.fillAmount += 1 / cdTime * Time.deltaTime;
            if (imageCoolDown.fillAmount >= 1)
            {
                imageCoolDown.fillAmount = 0;

                isCoolDown = false;
                Shoot();
            }

        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Shoot();
        isCoolDown = false;
    }
}