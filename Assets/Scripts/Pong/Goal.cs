using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private string winText;
    private GoalUI _goalUI;
    public event UnityAction<string> Win;

    private void Start()
    {
        _goalUI = gameObject.GetComponent<GoalUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.GetComponent<Ball>();
        if (ball != null)
        {
            ball.AgainPlay();
            _player.AddCount();
            if (_player.IsWin())
            {
                ball.StopGame();
                Win?.Invoke(winText);
            }
        }
    }

    public void RestartGame()
    {
        _goalUI.RestartGame();
    }
}
