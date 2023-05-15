using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= -7.5f)
        {
            Vector2 vector2 = transform.position;
            vector2.x = 2.0f;
            vector2.y = Random.Range(-2.5f, 3.0f);
            transform.position = vector2;
        }

    }
}
