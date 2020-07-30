using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardGrid : MonoBehaviour
{
    [SerializeField] private float _ceilWidth;
    [SerializeField] private GameObject _ceilTemplate;
    [SerializeField] private Vector2Int _startGridPosition;
    [SerializeField] private Vector2Int _endGridPosition;
    private Vector2Int _maxCeil = new Vector2Int(8,8);
    private List<GameObject> _ceils = new List<GameObject>();

    public ChessBoardGrid(float ceilWidth)
    {
        _ceilWidth = ceilWidth;
    }

    private void Start()
    {
        CreateChessBoard(_startGridPosition, _endGridPosition);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var ceilCenter = GridToWorldPosition(WorldToGridPosition(mousePosition));
            GameObject findCeil = _ceils.Find(x => x.transform.position == new Vector3(ceilCenter.x, ceilCenter.y, 0));
            Debug.Log(findCeil);
            if (findCeil)
            {
                Debug.Log("???");
            }
        }
    }

    public void SetCeilGrid()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }

    public void FillCeil()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var ceilCenter = GridToWorldPosition(WorldToGridPosition(mousePosition));
        Instantiate(_ceilTemplate, ceilCenter, Quaternion.identity);
    }

    public Vector2 GridToWorldPosition(Vector2Int gridPosition)
    {
        return new Vector2(
            gridPosition.x * _ceilWidth - _ceilWidth / 2,
            gridPosition.y * _ceilWidth - _ceilWidth / 2
            );
    }

    public Vector2Int WorldToGridPosition(Vector2 worldPosition)
    {
        return new Vector2Int(
            Mathf.CeilToInt(worldPosition.x / _ceilWidth),
            Mathf.CeilToInt(worldPosition.y / _ceilWidth)
            );
    }

    public void CreateChessBoard(Vector2Int startGridPosition, Vector2Int endGridPosition)
    {
        int horizontal = 1;
        int vertical = 1;
        for (int y = startGridPosition.y; y < endGridPosition.y; y++)
        {
            for (int x = startGridPosition.x; x < endGridPosition.x; x++)
            {
                var ceilCenter = GridToWorldPosition(new Vector2Int(x, y));
                var newCeilObject = Instantiate(_ceilTemplate, ceilCenter, Quaternion.identity);
                _ceils.Add(newCeilObject);
                newCeilObject.GetComponent<Ceil>().Init(horizontal, vertical);
                newCeilObject.SetActive(false);
                horizontal++;
            }
            horizontal = 1;
            vertical++;
        }
    }
}
