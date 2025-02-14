using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject foodPrefab;
    public Player player;
    public TextMeshProUGUI scoreText;
    public GameObject pauseMenu;
    public GameObject endMenu;
    public TextMeshProUGUI endScoreText;


    private GameObject _currentFood;
    private int _score = 0;
    private bool _isPaused = false;


    private const float CellSize = 0.3f;
    private const int GridSizeX = 20;
    private const int GridSizeY = 13;

    private void Start()
    {
        SpawnFood();
        scoreText.text = _score.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !endMenu.activeSelf)
            TogglePause();

        if (Input.GetKeyDown(KeyCode.Space) && endMenu.activeInHierarchy)
            ResetGame();
    }

    private void SpawnFood()
    {
        // Generate a random integer index, then multiply by cellSize to snap to the grid
        var x = Random.Range(-GridSizeX + 1, GridSizeX - 1) * CellSize;
        var y = Random.Range(-GridSizeY + 1, GridSizeY - 1) * CellSize;

        var rndPos = new Vector2(x, y);

        _currentFood = Instantiate(foodPrefab, rndPos, Quaternion.identity); // last is rotation
    }

    private void ResetGame()
    {
        Time.timeScale = 1f;
        endMenu.SetActive(false);
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

    private void TogglePause()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
        pauseMenu.SetActive(_isPaused);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        ToggleEndMenu();
    }

    private void ToggleEndMenu()
    {
        endMenu.SetActive(!endMenu.activeSelf);
        endScoreText.text = "SCORE: " + _score;
    }
}