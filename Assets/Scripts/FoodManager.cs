using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject food;
    
    private void Start()
    {
        SpawnFood();
    }

    // Triggered by UnityEvent
    public void SpawnFood()
    {
        const float cellSize = 0.3f;
        const int gridSizeX = 20 - 1;
        const int gridSizeY = 13 - 1;

        // Generate a random integer index, then multiply by cellSize to snap to the grid
        var x = Random.Range(-gridSizeX, gridSizeX) * cellSize;
        var y = Random.Range(-gridSizeY, gridSizeY) * cellSize;

        var rndPos = new Vector2(x, y);

        Instantiate(food, rndPos, Quaternion.identity); // last is rotation
    }
}
