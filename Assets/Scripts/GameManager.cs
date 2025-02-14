using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject foodPrefab;
    public Player player;
    public TextMeshProUGUI scoreText;

    private GameObject _currentFood;
    private int _score = 0;

    private const float CellSize = 0.3f;
    private const int GridSizeX = 20;
    private const int GridSizeY = 13;

    private void Start()
    {
        SpawnFood();
        scoreText.text = _score.ToString();
    }

    private void SpawnFood()
    {
        // Generate a random integer index, then multiply by cellSize to snap to the grid
        var x = Random.Range(-GridSizeX + 1, GridSizeX - 1) * CellSize;
        var y = Random.Range(-GridSizeY + 1, GridSizeY - 1) * CellSize;

        var rndPos = new Vector2(x, y);

        _currentFood = Instantiate(foodPrefab, rndPos, Quaternion.identity); // last is rotation
    }

    public void ResetGame()
    {
        _score = 0;
        scoreText.text = _score.ToString();
        player.ResetPlayer();

        if (!_currentFood) return;
        Destroy(_currentFood);
        SpawnFood();
    }

    public void FoodEaten()
    {
        AddScore();
        player.AddTail();
        player.IncreaseSpeed();

        if (!_currentFood) return;
        Destroy(_currentFood);
        SpawnFood();
    }

    private void AddScore()
    {
        _score++;
        scoreText.text = _score.ToString();
    }
}