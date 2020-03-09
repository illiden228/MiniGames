using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedY;
    private float _startSpeedX;
    private float dx = 1;
    private float dy = 1;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
        _rigidbody.velocity = new Vector2(dx * _speedX, dy * _speedY);
        _startSpeedX = _speedX;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            dx = -dx;
            _rigidbody.velocity = new Vector2(dx *_speedX, dy * _speedY);
        }
        else
        {
            dy = -dy;
            _rigidbody.velocity = new Vector2(dx * _speedX, dy * _speedY);
        }
    }

    public void AddSpeed()
    {
        _speedX += 1f;
        _rigidbody.velocity = new Vector2(dx * _speedX, dy * _speedY);
    }

    public void AgainPlay()
    {
        AddSpeed();
        transform.position = new Vector3(0, 0, 0);
    }

    public void StopGame()
    {
        transform.position = new Vector3(0, 0, 0);
        _rigidbody.velocity = Vector2.zero;
    }

    public void RestartGame()
    {
        _speedX = _startSpeedX;
        _rigidbody.velocity = new Vector2(dx * _speedX, dy * _speedY);
    }
}
