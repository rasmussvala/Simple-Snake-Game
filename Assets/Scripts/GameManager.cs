using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject foodPrefab;
    public Player player;
    
    private GameObject _currentFood;

    private const float CellSize = 0.3f;
    private const int GridSizeX = 20;
    private const int GridSizeY = 13;
    
    private void Start()
    {
        SpawnFood();
    }

    private void Update()
    {
        var pos = player.transform.position;
        
        if(pos.x is >= GridSizeX * CellSize or <= -GridSizeX * CellSize || 
           pos.y is >= GridSizeY * CellSize or <= -GridSizeY * CellSize)
            ResetGame();
    }

    // Triggered by UnityEvent
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
        player.ResetPlayer();
    }

    public void FoodEaten()
    {
        if (_currentFood != null)
            Destroy(_currentFood);
        
        SpawnFood();
        player.AddTail();
    }
}
