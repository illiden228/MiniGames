using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<int> Goal; 
    [SerializeField] private KeyCode _upKey;
    [SerializeField] private KeyCode _downKey;
    [SerializeField] private float _speed = 2;
    private Rigidbody2D _rigidbody;
    private bool _isPlay = true;
    private int _count;
    private Vector3 _startPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
        _rigidbody.freezeRotation = true;
        _startPosition = transform.position;
        _count = 0;
    }

    private void Update()
    {
        if(_isPlay)
        {
            MovingPlatform(_upKey, _downKey);
        }
    }

    private void MovingPlatform(KeyCode upKey, KeyCode downKey)
    {
        float speed = _speed * Time.deltaTime;

        if (Input.GetKey(upKey))
        {
            _rigidbody.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            _rigidbody.velocity = -Vector2.up * speed;
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    public void AddCount()
    {
        _count++;
        Goal?.Invoke(_count);
    }

    public int GetCount()
    {
        return _count;
    }

    public void StopPlay()
    {
        _isPlay = false;
    }

    public bool IsWin()
    {
        if (_count == 5)
        {
            return true;
        }
        return false;
    }

    public void ReatartGame()
    {
        transform.position = _startPosition;
        _count = 0;
        _isPlay = true;
    }
}
