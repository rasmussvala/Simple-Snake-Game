using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public float startSpeed = 5f; // Cells per second
    public GameObject tailPrefab;

    private Vector2 _direction = Vector2.right;
    private Vector2 _lastDirection = Vector2.right;
    private float _speed;
    private float _moveTime;
    private readonly List<Transform> _tail = new();


    private void Start()
    {
        _speed = startSpeed;
    }

    private void Update()
    {
        ChangeDirection();
        Move();
    }

    private void ChangeDirection()
    {
        if (Input.GetKeyDown(KeyCode.W) && _lastDirection != Vector2.down)
            _direction = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.S) && _lastDirection != Vector2.up)
            _direction = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.A) && _lastDirection != Vector2.right)
            _direction = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.D) && _lastDirection != Vector2.left)
            _direction = Vector2.right;
    }

    private void Move()
    {
        if (!(Time.time > _moveTime)) return;

        const float cellSize = 0.3f;
        var newPosition = transform.position + (Vector3)_direction * cellSize;

        // Move Tail (If it exists)
        if (_tail.Count > 0)
        {
            for (var i = _tail.Count - 1; i > 0; i--)
                _tail[i].position = _tail[i - 1].position;

            _tail[0].position = transform.position;
        }

        transform.position = newPosition;
        _lastDirection = _direction;
        _moveTime = Time.time + 1 / _speed;
    }

    public void ResetPlayer()
    {
        foreach (var segment in _tail)
            Destroy(segment.gameObject);

        _tail.Clear();
        _moveTime = 0;
        _direction = Vector2.right;
        _lastDirection = Vector2.right;
        transform.position = Vector2.zero;
        _speed = startSpeed;
    }

    public void AddTail()
    {
        Vector3 spawnPosition;
        if (_tail.Count > 0)
            spawnPosition = _tail[^1].position;
        else
            spawnPosition = transform.position - (Vector3)_direction * 0.3f;

        var newTail = Instantiate(tailPrefab, spawnPosition, Quaternion.identity);
        _tail.Add(newTail.transform);
    }

    public void IncreaseSpeed()
    {
       _speed += 0.5f;
    }
}