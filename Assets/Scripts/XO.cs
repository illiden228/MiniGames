using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XO : MonoBehaviour
{
    public bool PlayerMove = true;
    public Sprite imageX;
    public Sprite imageO;

    public GameObject MoveX;
    public GameObject MoveO;

    private Button[] _buttons;
    private char[,] _players;
    private int _scoreToVictoryX = 0;
    private int _scoreToVictoryO = 0;
    void Start()
    {
        PlayerMoveHelp();
        _buttons = GetComponentsInChildren<Button>();
        _players = new char[3, 3];

        foreach (Button button in _buttons)
        {
            button.onClick.AddListener(delegate { OnButtonClick(button); });
        }
    }

    public void OnButtonClick(Button button)
    {
        if (PlayerMove)
        {
            button.GetComponent<Image>().sprite = imageX;
            PlayerMove = !PlayerMove;
        }
        else
        {
            button.GetComponent<Image>().sprite = imageO;
            PlayerMove = !PlayerMove;
        }
        PlayerMoveHelp();
        Victory();
    }

    public void PlayerMoveHelp()
    {
        MoveX.SetActive(PlayerMove);
        MoveO.SetActive(!PlayerMove);
    }

    public void Victory()
    {
        int k = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_buttons[k].GetComponent<Image>().sprite == imageX)
                {
                    _players[i, j] = 'x';
                }
                else if (_buttons[k].GetComponent<Image>().sprite == imageO)
                {
                    _players[i, j] = 'o';
                }
                Debug.Log("Players[" + i + ", " + j + "] = " + _players[i, j]);
                k++;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            int scoreX = 0;
            int scoreO = 0;
            for (int j = 0; j < 3; j++)
            {
                if (_players[i,j] == 'x')
                {
                    Debug.Log("---x---" + i + "---" + j + "---");
                    for (int v = 0; v < 3; v++)  //vertival X
                    {
                        if(_players[v,j] == 'x')
                        {
                            scoreX++;
                            Debug.Log("X - vert " + v + ": " + scoreX);
                        }
                    }
                    if(_scoreToVictoryX < scoreX)
                    {
                        _scoreToVictoryX = scoreX;
                    }
                    scoreX = 0;
                    for (int h = 0; h < 3; h++)  //horizontal X
                    {
                        if (_players[i, h] == 'x')
                        {
                            scoreX++;
                            Debug.Log("X - hor " + h + ": " + scoreX);
                        }
                    }
                    if (_scoreToVictoryX < scoreX)
                    {
                        _scoreToVictoryX = scoreX;
                    }
                    scoreX = 0;
                    for (int diag = 0; diag < 3; diag++)
                    {
                        if (_players[diag, diag] == 'x')
                        {
                            scoreX++;
                            Debug.Log("X - diag1 " + diag + ": " + scoreX);
                        }
                    }
                    if (_scoreToVictoryX < scoreX)
                    {
                        _scoreToVictoryX = scoreX;
                    }
                    scoreX = 0;
                    for (int diagTwo = 0; diagTwo < 3; diagTwo++)
                    {
                        if (_players[2 - diagTwo, 2 - diagTwo] == 'x')
                        {
                            scoreX++;
                            Debug.Log("X - diag2 " + diagTwo + ": " + scoreX);
                        }
                    }
                    if (_scoreToVictoryX < scoreX)
                    {
                        _scoreToVictoryX = scoreX;
                    }
                    scoreX = 0;
                }
                else if (_players[i, j] == 'o')
                {
                    Debug.Log("---o---" + i + "---" + j + "---");
                    for (int v = 0; v < 3; v++)  //vertival O
                    {
                        if (_players[v, j] == 'o')
                        {
                            scoreO++;
                            Debug.Log("O - vert " + v + ": " + scoreO);
                        }
                    }
                    if (_scoreToVictoryO < scoreO)
                    {
                        _scoreToVictoryO = scoreO;
                    }
                    scoreO = 0;
                    for (int h = 0; h < 3; h++)  //horizontal O
                    {
                        if (_players[i, h] == 'o')
                        {
                            scoreO++;
                            Debug.Log("O - hor " + h + ": " + scoreO);
                        }
                    }
                    if (_scoreToVictoryO < scoreO)
                    {
                        _scoreToVictoryO = scoreO;
                    }
                    scoreO = 0;
                    for (int diag = 0; diag < 3; diag++)
                    {
                        if (_players[diag, diag] == 'o')
                        {
                            scoreO++;
                            Debug.Log("O - diag1 " + diag + ": " + scoreO);
                        }
                    }
                    if (_scoreToVictoryO < scoreO)
                    {
                        _scoreToVictoryO = scoreO;
                    }
                    scoreO = 0;
                    for (int diagTwo = 0; diagTwo < 3; diagTwo++)
                    {
                        if (_players[2 - diagTwo, 2 - diagTwo] == 'o')
                        {
                            scoreO++;
                            Debug.Log("O - diag2 " + diagTwo + ": " + scoreO);
                        }
                    }
                    scoreO = 0;
                }
            }
        }

        Debug.Log("o: " + _scoreToVictoryO + ", x: " + _scoreToVictoryX);

        if (_scoreToVictoryX == 3)
        {
            Debug.Log("vic x");
            EndGame();
        }
        else if (_scoreToVictoryO == 3)
        {
            Debug.Log("vic o");
            EndGame();
        }
    }

    public void EndGame()
    {
        foreach(Button button in _buttons)
        {
            button.interactable = false;
        }
    }
}
