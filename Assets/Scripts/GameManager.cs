using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    private bool _isGameover = false;
    private bool _isGameplay = false;
    private UIManager _uiManager;
    [SerializeField] private AudioClip _SwooshAudioClip;
    [SerializeField] private SpriteRenderer _bg;
    [SerializeField] private Sprite _DayBgImg;
    [SerializeField] private Sprite _NightBgImg;
    private DateTime _Time = new DateTime();
    void Start()
    {
        checkTime();
        _uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();
        if(_uiManager != null )
        {
            _uiManager.ActiveGameoverMessage(false);
            _uiManager.ActiveRestartButton(false);
            _uiManager.ActiveMessage(true);
        }
        Time.timeScale = 0;
    }

    void Update()
    {
        if(Input.anyKey && _isGameplay == false)
        {
            _uiManager.ActiveMessage(false);
            Time.timeScale = 1f;
            AudioSource.PlayClipAtPoint(_SwooshAudioClip, transform.position);
            _isGameplay=true;
        }

        if(_isGameover)
        {
            _uiManager.ActiveGameoverMessage(true);
            _uiManager.ActiveRestartButton(true);
        }
    }

    public void Gameover()
    {
        _isGameover = true;
    }

    public void startGame()
    {
        SceneManager.LoadScene(0);
    }

    private void checkTime()
    {
        _Time = DateTime.Now;
        if (_Time.Hour < 6 || (_Time.Hour > 18))
        {
            _bg.GetComponent<SpriteRenderer>().sprite = _NightBgImg;
        }
        else
        {
            _bg.GetComponent<SpriteRenderer>().sprite = _DayBgImg;
        }
    }
}
