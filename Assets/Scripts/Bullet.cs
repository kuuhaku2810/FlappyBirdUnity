using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 3f;

    private void Start()
    {
        Invoke(nameof(DestroyBullet), destroyTime);
    }

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public void Shoot()
    {
        gameObject.SetActive(true);
    }
}
