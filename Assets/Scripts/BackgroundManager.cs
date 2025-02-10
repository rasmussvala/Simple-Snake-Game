using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject cell;
    public GameObject collisionCell; 

    private void Start()
    {
        const float cellSize = 0.3f;
        const int gridSizeX = 20;
        const int gridSizeY = 13;

        for (var i = -gridSizeX; i <= gridSizeX; i++)
        for (var j = -gridSizeY; j <= gridSizeY; j++)
        {
            if (i == -gridSizeX || i == gridSizeX || j == -gridSizeY || j == gridSizeY)
                Instantiate(collisionCell, new Vector3(i * cellSize, j * cellSize, 1f), Quaternion.identity);
            else
                Instantiate(cell, new Vector3(i * cellSize, j * cellSize, 1f), Quaternion.identity);
        }
    }
}
