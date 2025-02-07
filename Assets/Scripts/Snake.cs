using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private Vector2 _lastDirection = Vector2.right; 
    public float cellSize = 0.3f;
    public float speed = 1f; // Cells per second

    private float _moveTime;
    private List<Transform> _tail = new(); 

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

        var newPosition = transform.position + (Vector3)_direction * cellSize;

        // Move Tail (If it exists)
        if (_tail.Count > 0)
        {
            for (var i = _tail.Count - 1; i > 0; i--)
            {
                _tail[i].position = _tail[i - 1].position;
            }
            _tail[0].position = transform.position;
        }

        transform.position = newPosition;
        _lastDirection = _direction; 
        _moveTime = Time.time + 1 / speed;
    }
}