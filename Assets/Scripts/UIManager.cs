using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _gameoverImg;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _Message;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if(_player!= null)
        {
            _scoreText.text = "" + _player.getScore();
        }
    }

    public void ActiveGameoverMessage(bool status)
    {
        _gameoverImg.SetActive(status);
    }

    public void ActiveRestartButton(bool status)
    {
        _restartButton.SetActive(status);
    }

    public void ActiveMessage(bool status)
    {
        _Message.SetActive(status);
    }
}

