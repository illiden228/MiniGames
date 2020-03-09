using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PongCount : MonoBehaviour
{
    [SerializeField] private Goal _goalPlayerOne;
    [SerializeField] private Goal _goalPlayerTwo;
    [SerializeField] private Ball _ball;
    [SerializeField] private GameObject _winnerPanel;
    [SerializeField] private TMP_Text _winnerText;

    private void Start()
    {
        _goalPlayerOne.Win += WinnerAnnounced;
        _goalPlayerTwo.Win += WinnerAnnounced;
    }

    public void WinnerAnnounced(string text)
    {
        _winnerPanel.SetActive(true);
        _winnerText.text = text;
    }

    public void RestartGame()
    {
        _goalPlayerOne.RestartGame();
        _goalPlayerTwo.RestartGame();
        _ball.RestartGame();
        _winnerPanel.SetActive(false);
    }
}
