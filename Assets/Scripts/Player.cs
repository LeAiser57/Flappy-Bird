using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _velocity = 150f;
    [SerializeField] private float _rotateSpeed = 10f;
    [SerializeField] private int _score = 0;
    private GameManager _gameManager;
    [SerializeField] private AudioClip _PointAudioClip;
    [SerializeField] private AudioClip _HitAudioClip;
    [SerializeField] private AudioClip _FlapAudioClip;
    private AudioSource _audio;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _audio = gameObject.GetComponent<AudioSource>();    
    }

    void Update()
    {
        if (Input.anyKeyDown) {
            Flap();
            
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0, _rb.velocity.y  * _rotateSpeed);
    }

    private void Flap()
    {
        _audio.clip = _FlapAudioClip;
        _audio.Play();
        _rb.velocity = Vector2.up * _velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "point")
        {
            _increaseScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Deadzone") || other.gameObject.CompareTag("Obstacle"))
        {
            _gameManager.Gameover();
            AudioSource.PlayClipAtPoint(_HitAudioClip, transform.position);
            Destroy(this.gameObject);
        }
    }

    private void _increaseScore()
    {
        _score++;
        AudioSource.PlayClipAtPoint(_PointAudioClip, transform.position);
    }

    public int getScore()
    {
        return _score;
    }
}
