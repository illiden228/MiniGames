using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCount;
    [SerializeField] private Player _player;

    private void Start()
    {
        _textCount.text = "0";
        _player.Goal += AddCountText;
    }

    public void AddCountText(int count)
    {
        _textCount.text = count.ToString();
    }

    public void RestartGame()
    {
        _player.ReatartGame();
        _textCount.text = "0";
    }
}
