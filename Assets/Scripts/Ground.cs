using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    [SerializeField] private float _speed = 2.0f;

    void Update()
    {
        if(transform.position.x < 1)
        {
            transform.position = new Vector2(4, transform.position.y);
        }
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
