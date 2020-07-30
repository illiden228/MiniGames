using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceil : MonoBehaviour
{
    private int _horizontalNumber;
    private int _verticalNumber;

    public void Init(int horizontal, int vertical)
    {
        _horizontalNumber = horizontal;
        _verticalNumber = vertical;
        Debug.Log($"Новая ячейка {_horizontalNumber} - {_verticalNumber}");
    }

    public Vector2Int GetPosition()
    {
        return new Vector2Int(_horizontalNumber, _verticalNumber);
    }
}
