using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour 
{
    private Colors _color;
    private Chassmen _chassmen;
    private Ceil _startPosition;
    private Ceil _currentPosition;

    public Figure(Colors color)
    {
        _color = color;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public  void Select()
    {

    }
}

public enum Chassmen
{
    King,
    Queen,
    Bishop,
    knight,
    Castle,
    Pawn
}

public enum Colors
{
    Black, 
    White
}
