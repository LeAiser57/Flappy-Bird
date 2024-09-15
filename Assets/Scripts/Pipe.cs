using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;

    void Update()
    {
        move();
    }

    private void move()
    {
        if (transform.position.x < -12.0f) Destroy(this.gameObject);
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
